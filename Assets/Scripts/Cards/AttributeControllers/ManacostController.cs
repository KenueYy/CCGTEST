using Cards.AttributeControllers.Interfaces;
using Cards.AttributeControllers.UI;
using Cards;
using System;
using UnityEngine;

namespace Cards.AttributeControllers {

    public class ManacostController : MonoBehaviour, IAttributeController, IAttributeInitializer {
        public event Action<int> onValueChange;

        private int _baseManacost;
        private int _currentManacost;

        private IMutable<int> _manacostUI;
        #region IAttributeInitializer
        public void Initialize(CardObject card) {
            Subscribe();
            _baseManacost = card.Manacost;

            Increase(card.Manacost);
        }
        #endregion

        #region IAttributeController

        public void Increase(int value) {
            _currentManacost += value;
            onValueChange?.Invoke(_currentManacost);
        }

        public void Decrease(int value) {

            if (_currentManacost - value < 0) {
                _currentManacost = 0;
            } else {
                _currentManacost -= value;
            }
            onValueChange?.Invoke(_currentManacost);
        }

        #endregion

        private void Subscribe() {

            _manacostUI = GetComponentInChildren<ManacostUI>();
            onValueChange += _manacostUI.SetValue;

        }

        private void Unsubscribe() {

            onValueChange -= _manacostUI.SetValue;

        }

        private void OnDestroy() {
            Unsubscribe();
        }
    }
}
