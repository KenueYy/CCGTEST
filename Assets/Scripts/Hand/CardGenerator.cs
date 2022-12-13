using Cards;
using UnityEngine;

namespace Hand {
    public static class CardGenerator {
        public static CardObject Generate() {
            CardObject card = new CardObject() {
                ImageWidth = 1800,
                ImageHeight = 900,
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
