using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Card {

    [CreateAssetMenu(menuName = "CreateCard")]
    public class CardObject : ScriptableObject {
        public int Manacost;
        public string Title;
        public string Description;
        public int Attack;
        public int Health;
    }
}
