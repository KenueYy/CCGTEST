using Cards.AttributeControllers.Interfaces;
using UnityEngine;

namespace Cards.AttributeControllers {
    public class TitleController : MonoBehaviour, IAttributeInitializer {

        private IMutable<string> _titleUI;
        public void Initialize(CardObject card) {
            _titleUI = GetComponentInChildren<TitleUI>();
            _titleUI.SetValue(card.Title);
        }

    }
}
