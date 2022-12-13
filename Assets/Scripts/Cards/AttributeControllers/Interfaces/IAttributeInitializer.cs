namespace Cards.AttributeControllers.Interfaces {

    interface IAttributeInitializer {
        bool isInitialized { get; set; }
        void Initialize(CardObject card);
    }
}
