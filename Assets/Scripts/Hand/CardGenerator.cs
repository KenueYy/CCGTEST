using Cards;
using Utillites;

namespace Hand {
    public static class CardGenerator {
        public static CardObject Generate() {
            CardObject card = new CardObject() {
                ImageWidth = 1800,
                ImageHeight = 900,
                Title = $"Карта {Randomizer.RandomIntValue(1,1000)}",
                Description = $"Наносит {Randomizer.RandomIntValue(1, 50)} урона",
                Manacost = Randomizer.RandomIntValue(1, 10),
                Attack = Randomizer.RandomIntValue(1, 12),
                Health = Randomizer.RandomIntValue(1, 15),
            };
            return card;
        }
    }
}
