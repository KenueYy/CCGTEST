using UnityEngine;

namespace Cards {

    [CreateAssetMenu(menuName = "CreateCard")]
    public class CardObject : ScriptableObject {
        public int ImageWidth;
        public int ImageHeight;
        public int Manacost;
        public string Title;
        public string Description;
        public int Attack;
        public int Health;
    }
}
