using Cards.AttributeControllers.Interfaces;
using Cards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utillites.ObjectPooller;
using System;
using UnityEngine.Pool;
using Utillites;
using Hand;
using System.Threading.Tasks;
using Hand.Interfaces;

namespace Hand {
    public class HandCards : MonoBehaviour, IHand {
        public event Action onCardListChanged;

        [SerializeField]
        private List<Card> cards;

        [SerializeField]
        private Transform cardsContainer;

        private async void Start() {
            var generateCards = await HandGenerator.instance.TakeCards();
            Initialize(generateCards);
        }
        public List<Card> GetCardList() {
            return cards;
        }

        public void RemoveCard(Card card) {
            var index = cards.FindIndex(x => x == card);
            onCardListChanged -= cards[index].GetComponentInChildren<ICardTransform>().SetPoint;
            cards.RemoveAt(index);
            onCardListChanged?.Invoke();
        }

        public void AddCard(Card card) {
            cards.Add(card);
            onCardListChanged += card.GetComponentInChildren<ICardTransform>().SetPoint;
            onCardListChanged?.Invoke();
        }
        private async void Initialize(List<Card> generateCards) {
            foreach (var card in generateCards) {
                await Load(700);
                card.Initialize();
                card.transform.parent = cardsContainer;
            }

            await Load(1500);
            generateCards.ForEach(x => {
                AddCard(x);
            });
        }


        private void OnDestroy() {
            cards.ForEach(x => {
                onCardListChanged -= x.GetComponentInChildren<ICardTransform>().SetPoint;
            });
        }

        private async Task Load(int time) {
            await Task.Delay(time);
        }
    }
}
