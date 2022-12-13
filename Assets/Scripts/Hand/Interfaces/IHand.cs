using Cards;
using System.Collections.Generic;

namespace Hand.Interfaces {

    interface IHand {
        void RemoveCard(Card card);
        void AddCard(Card card);
        List<Card> GetCardList();
    }
}
