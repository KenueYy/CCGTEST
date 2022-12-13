using Cards.AttributeControllers.Enums;
using Cards.AttributeControllers.Interfaces;
using System;
using UnityEngine;
using Utillites.Interfaces;

namespace Cards.AttributeControllers {
    public class DescriptionsController : MonoBehaviour, IAttributeInitializer, ISilence {

        public event Action<bool> onSilence;

        private IMutable<string> _descriptionText;
        private ILabilized _descriptionView;

        public bool isInitialized {
            get {
                return _isInitialized;
            }
            set {
                _isInitialized = value;
            }
        }

        private bool _isInitialized = false;

        public void Initialize(CardObject card) {
            Subscribe();
            _descriptionText.SetValue(card.Description);
            isInitialized = true;
        }

        [ContextMenu("Silence")]
        public void Silence() {
            _descriptionText.SetValue(DiscriptionStatus.Silenced.ToString());
        }

        private void Subscribe() {
            _descriptionText = GetComponentInChildren<DescriptionsUI>();

            _descriptionView = GetComponentInChildren<ILabilized>();
            onSilence += _descriptionView.SetActive;
        }

        private void Unscribe() {

            if (!isInitialized) {
                return;
            }

            onSilence -= _descriptionView.SetActive;
        }

        private void OnDestroy() {
            Unscribe();
        }
    }
}
