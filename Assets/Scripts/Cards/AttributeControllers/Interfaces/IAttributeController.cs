using System;

namespace Cards.AttributeControllers.Interfaces {

    interface IAttributeController {

        event Action<int> onValueChange;
        void Initialize(int value);
        void Increase(int value);
        void Decrease(int value);
    }
}