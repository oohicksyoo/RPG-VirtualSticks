using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RPG.VirtualSticks {
    public class Knob : MonoBehaviour {

        private Touch currentTouch;

        public void Update() {
            var touchCount = Input.touchCount;
            if (touchCount > 0) {
                currentTouch = Input.GetTouch(touchCount - 1);
                if (EventSystem.current.IsPointerOverGameObject(currentTouch.fingerId)) {
                    Debug.LogFormat("Touch");
                    switch (currentTouch.phase) {
                        case TouchPhase.Began:
                            Debug.Log("Begin");
                            break;
                        case TouchPhase.Moved:
                            Debug.Log("Moved");
                            break;
                        case TouchPhase.Stationary:
                            Debug.Log("Stationary");
                            break;
                        case TouchPhase.Ended:
                            Debug.Log("Ended");
                            break;
                        case TouchPhase.Canceled:
                            Debug.Log("Canceled");
                            break;
                    }
                }
            }
        }
    }
}
