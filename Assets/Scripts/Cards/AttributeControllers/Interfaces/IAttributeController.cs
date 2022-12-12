using System;

namespace Cards.AttributeControllers.Interfaces {

    interface IAttributeController {

        event Action<int> onValueChange;
        void Increase(int value);
        void Decrease(int value);
    }
}