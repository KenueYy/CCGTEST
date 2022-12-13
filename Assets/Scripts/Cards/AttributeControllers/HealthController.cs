using Cards.AttributeControllers.Interfaces;
using Cards.AttributeControllers.UI;
using System;
using UnityEngine;

namespace Cards.AttributeControllers {
    public class HealthController : MonoBehaviour, IAttributeController, IAttributeInitializer {

        public event Action<int> onValueChange;

        private int _baseHealth;
        private int _currentHealth;

        private IMutable<int> _healthUI;
        public bool isInitialized {
            get {
                return _isInitialized;
            }
            set {
                _isInitialized = value;
            }
        }

        private bool _isInitialized = false;

        #region IAttributeInitializer

        public void Initialize(CardObject card) {

            Subscribe();

            _baseHealth = card.Health;
            Increase(card.Health);
            isInitialized = true;
        }

        #endregion

        #region IAttributeController

        public void Increase(int value) {
            _currentHealth += value;
            onValueChange?.Invoke(_currentHealth);
        }

        public void Decrease(int value) {

            if (_currentHealth - value <= 0) {
                Destroy(GetComponentInParent<Card>().gameObject);
                return;
            }

            _currentHealth -= value;
            onValueChange?.Invoke(_currentHealth);
        }

        #endregion


        private void Subscribe() {

            _healthUI = GetComponentInChildren<HealthUI>();
            onValueChange += _healthUI.SetValue;

        }

        private void Unsubscribe() {

            if (!isInitialized) {
                return;
            }

            onValueChange -= _healthUI.SetValue;

        }

        private void OnDestroy() {
            Unsubscribe();
        }

    }
}
