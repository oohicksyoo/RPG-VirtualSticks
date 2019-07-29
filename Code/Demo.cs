using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.VirtualSticks {
    public class Demo : MonoBehaviour {

        public void Start() {
            Input.simulateMouseWithTouches = true;
        }

        public void OnAxisUpdate(Vector2 vect) {
            Debug.Log(vect);
        }

        public void OnAngleUpdate(float angle) {
            Debug.Log(angle);
        }
    }
}
