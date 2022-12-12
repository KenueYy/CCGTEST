using Cards;
using UnityEngine;

namespace Utillites {
    public static class CardGenerator {
        public static CardObject Generate() {
            CardObject card = new CardObject() {
                Title = $"Карта {RandomValue()}",
                Description = $"Наносит {RandomValue()} урона",
                Manacost = RandomValue(),
                Attack = RandomValue(),
                Health = RandomValue(),
            };
            return card;
        }
        private static int RandomValue() {
            int value = Random.Range(1, 10);
            return value;
        }
    }
}
