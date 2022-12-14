using Cards;
using Cards.AttributeControllers.Interfaces;
using Hand;
using Hand.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Utillites;

namespace ChangeStats {

    public class ChangeStatsManger : MonoBehaviour {

        [SerializeField]
        private Button button;

        private IHand _hand;

        private void Awake() {
            _hand = FindObjectOfType<HandCards>();
            button.onClick.AddListener(Enumeration);
        }

        private async void Enumeration() {
            List<Card> cards = _hand.GetCardList();
            for (int i = 0; i < cards.Count; i++) {
                var controllers = cards[i].GetComponentsInChildren<IAttributeController>();
                ChangeStats(controllers);
                await Load(500);
            }
            await Load(3000);
            cards = _hand.GetCardList();
            for (int i = cards.Count - 1; i >= 0; i--) {
                var controllers = cards[i].GetComponentsInChildren<IAttributeController>();
                ChangeStats(controllers);
                await Load(500);
            }

        }

        private void ChangeStats(IAttributeController[] controllers) {
            int choice = Randomizer.RandomIntValue(0, 1);
            IAttributeController controller = controllers[Randomizer.RandomIntValue(0, controllers.Length)];
            switch (choice) {
                case 0:
                    controller.Decrease(Randomizer.RandomIntValue(-2, 9));
                    return;

                case 1:
                    controller.Increase(Randomizer.RandomIntValue(-2, 9));
                    return;
            }
        }

        private async Task Load(int time) {
            await Task.Delay(time);
        }

    }
}
