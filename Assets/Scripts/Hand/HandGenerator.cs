using Cards;
using Cards.AttributeControllers.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;
using Utillites;
using Utillites.ObjectPooller;

namespace Hand {

    public class HandGenerator : MonoBehaviour {

        [SerializeField]
        private PoolObject poolObject;

        public static HandGenerator instance;
        private void Awake() {
            instance = this;
        }

        public async Task<List<Card>> TakeCards() {
            Spawner.instance.PreparationPool(poolObject);
            await Load(3500);

            List<Card> loadCards = new List<Card>();
            for (int i = 0; i < Randomizer.RandomIntValue(4,6); i++) {
                var cardObject = Spawner.instance.SpawnObject(poolObject);
                var card = cardObject.GetComponent<Card>();

                loadCards.Add(card);
            }

            return loadCards;
        }

        public PoolObject GetPoolObject() {
            return poolObject;
        }

        // Я знаю что юнити плохо работает с C# тасками, но подключать UniTask ради одного метода я не стал, как и корутину дожидающуюся выполнения другой корутины
        private async Task Load(int time) {
            await Task.Delay(time);
        }
       
    }
}
