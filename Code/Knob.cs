using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RPG.VirtualSticks {
    public class Knob : MonoBehaviour {

        private bool hasTouch;
        private Touch currentTouch;
        private Vector3 startPosition;

        public void Awake() {
            startPosition = transform.position;
        }

        public void SetSize(float sizePercent, float parentSize) {
            RectTransform rt = GetComponent<RectTransform>();
            Vector2 size = rt.sizeDelta;

            size.x = size.y = sizePercent * parentSize;

            rt.sizeDelta = size;
        }

        public void UpdateKnob() {
            var touchCount = Input.touchCount;
            var countIndex = touchCount - 1;

            if (touchCount > 0) {
                if (Input.touches.Any(x => EventSystem.current.IsPointerOverGameObject(x.fingerId) && !hasTouch) || (hasTouch && currentTouch.phase != TouchPhase.Ended)) {

                    currentTouch = (!hasTouch) ? Input.touches.SingleOrDefault(x => EventSystem.current.IsPointerOverGameObject(x.fingerId)) : Input.GetTouch(currentTouch.fingerId);

                    switch (currentTouch.phase) {
                        case TouchPhase.Began:
                            hasTouch = true;
                            break;
                        case TouchPhase.Moved:
                        case TouchPhase.Stationary:
                            hasTouch = true;
                            transform.position = currentTouch.position;
                            break;
                        case TouchPhase.Ended:
                        case TouchPhase.Canceled:
                            transform.position = startPosition;
                            hasTouch = false;
                            break;
                    }
                }
            } else if (hasTouch) {
                hasTouch = false;
            }
        }
    }
}
