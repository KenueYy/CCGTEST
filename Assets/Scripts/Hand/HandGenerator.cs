using Cards;
using Cards.AttributeControllers.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Utillites.ObjectPooller;

namespace Hand {

    public class HandGenerator : MonoBehaviour {
        public event Action onCardListChanged;

        [SerializeField]
        private List<Card> cards;

        [SerializeField]
        private PoolObject poolObject;

        [SerializeField]
        private Transform cardsContainer;

        private async void Awake() {

            List<Card> loadCards = new List<Card>();
            for (int i = 0; i < 5; i++) {
                var cardObject = Spawner.instance.SpawnObject(poolObject);
                var card = cardObject.GetComponent<Card>();
                await Load(1000);
                card.Initialize();
                card.transform.parent = cardsContainer;
                loadCards.Add(card);
            }
            await Load(1500);
            loadCards.ForEach(x => {
                AddCard(x);
            });

        }

        private async Task Load(int time) {
            await Task.Delay(time);
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
