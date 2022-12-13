using Cards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Table {
    public class Table : MonoBehaviour {

        private List<Card> cards = new List<Card>();

        public void AddCard(Card card) {
            cards.Add(card);
            card.transform.parent = transform;
        }
    }
}
