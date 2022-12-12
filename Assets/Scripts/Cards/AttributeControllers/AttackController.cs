using Cards.AttributeControllers.Interfaces;
using Cards.AttributeControllers.UI;
using System;
using UnityEngine;

namespace Cards.AttributeControllers {

    public class AttackController : MonoBehaviour, IAttributeController {

        public event Action<int> onValueChange;

        private int _baseAttack;
        private int _currentAttack;

        private IMutable _attackUI;

        public void Initialize(CardObject card) {

            _attackUI = GetComponentInChildren<AttackUI>();
            onValueChange += _attackUI.SetValue;

            Increase(card.Attack);
            _baseAttack = card.Attack;

        }

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

    }
}
