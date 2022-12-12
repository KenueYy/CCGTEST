using Cards.AttributeControllers.Interfaces;
using Cards.AttributeControllers.UI;
using System;
using UnityEngine;

namespace Cards.AttributeControllers {

    public class AttackController : MonoBehaviour, IAttributeController, IAttributeInitializer {

        public event Action<int> onValueChange;

        private int _baseAttack;
        private int _currentAttack;

        private IMutable<int> _attackUI;

        #region IAttributeInitializer

        public void Initialize(CardObject card) {

            Subscribe();

            Increase(card.Attack);
            _baseAttack = card.Attack;

        }
        #endregion

        #region IAttributeController

        public void Decrease(int value) {

            if (_currentAttack - value < 0) {
                _currentAttack = 0;
            } else {
                _currentAttack -= value;
            }
            onValueChange?.Invoke(_currentAttack);

        }

        public void Increase(int value) {

            _currentAttack += value;
            onValueChange?.Invoke(_currentAttack);

        }
        #endregion


        private void Subscribe() {

            _attackUI = GetComponentInChildren<AttackUI>();
            onValueChange += _attackUI.SetValue;

        }

        private void Unsubscribe() {

            onValueChange -= _attackUI.SetValue;

        }

        private void OnDestroy() {
            Unsubscribe();
        }
    }
}
