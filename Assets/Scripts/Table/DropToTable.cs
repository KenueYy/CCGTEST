using Cards;
using Cards.AttributeControllers.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Table {

    public class DropToTable : MonoBehaviour, IDropHandler {

        private Table _table;

        private void Awake() {
            _table = FindObjectOfType<Table>();
        }
        public void OnDrop(PointerEventData eventData) {
            var card = eventData.pointerDrag.gameObject;
            card.GetComponent<ICardTransform>().Freeze();
            _table.AddCard(card.GetComponent<Card>());
        }

    }
}
