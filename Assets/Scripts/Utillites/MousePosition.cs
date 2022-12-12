using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utillites {
    public class MousePosition : MonoBehaviour {

        public static Vector3 GetPointerPosition2D() {
            Vector3 vector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            vector.z = 0;
            return vector;
        }

        public static Vector2 GetPointerPositionOnWorldPoint(Vector3 position) {
            Vector2 vector = Camera.main.ScreenToWorldPoint(position);
            return vector;
        }
    }
}

