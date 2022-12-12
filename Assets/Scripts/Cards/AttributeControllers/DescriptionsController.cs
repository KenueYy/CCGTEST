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

        public void Initialize(CardObject card) {
            Subscribe();
            _descriptionText.SetValue(card.Description);
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
            onSilence -= _descriptionView.SetActive;
        }

        private void OnDestroy() {
            Unscribe();
        }
    }
}
