using System;

namespace Cards.AttributeControllers.Interfaces {
    interface ISilence {
        event Action<bool> onSilence;
        void Silence();
    }
}
