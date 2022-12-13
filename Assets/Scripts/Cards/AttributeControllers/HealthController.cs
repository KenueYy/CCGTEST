using Cards.AttributeControllers.Interfaces;
using Cards.AttributeControllers.UI;
using Hand;
using Hand.Interfaces;
using System;
using UnityEngine;
using Utillites.ObjectPooller;

namespace Cards.AttributeControllers {
    public class HealthController : MonoBehaviour, IAttributeController, IAttributeInitializer {

        public event Action<int> onValueChange;

        private int _baseHealth;
        private int _currentHealth;

        private IMutable<int> _healthUI;
        private Card _parent;
        private HandGenerator _handGenerator;
        private IHand _hand;
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

            if (_currentHealth + value <= 0) {
                Remove();
                return;
            }

            _currentHealth += value;
            onValueChange?.Invoke(_currentHealth);
        }

        public void Decrease(int value) {

            if (_currentHealth - value <= 0) {
                Remove();
                return;
            }

            _currentHealth -= value;
            onValueChange?.Invoke(_currentHealth);
        }

        #endregion
        public void Remove() {
            _hand.RemoveCard(_parent);
            Spawner.instance.DispawnObject(_parent.gameObject, _handGenerator.GetPoolObject());
        }

        private void Subscribe() {

            _healthUI = GetComponentInChildren<HealthUI>();
            onValueChange += _healthUI.SetValue;
            _parent = GetComponentInParent<Card>();
            _handGenerator = FindObjectOfType<HandGenerator>();
            _hand = FindObjectOfType<HandCards>();

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
