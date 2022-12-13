using Cards;
using Cards.AttributeControllers.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hand {

    public class HandGenerator : MonoBehaviour {
        public event Action onCardListChanged;

        [SerializeField]
        private List<Card> cards;

        private void Awake() {

            cards.ForEach(x => {
                onCardListChanged += x.GetComponentInChildren<ICardTransform>().SetPoint;
            });

        }

        public List<Card> GetCardList() {
            return cards;
        }

        public void RemoveCard(int index) {
            onCardListChanged -= cards[index].GetComponentInChildren<ICardTransform>().SetPoint;
            cards.RemoveAt(index);
            onCardListChanged?.Invoke();
        }

        public void AddCard(Card card) {
            cards.Add(card);
            onCardListChanged += card.GetComponentInChildren<ICardTransform>().SetPoint;
            onCardListChanged?.Invoke();
        }

        private void OnDestroy() {
            cards.ForEach(x => {
                onCardListChanged -= x.GetComponentInChildren<ICardTransform>().SetPoint;
            });
        }
    }
}
