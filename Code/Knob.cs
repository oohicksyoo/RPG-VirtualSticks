using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RPG.VirtualSticks {
    public class Knob : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler {

        private Touch currentTouch;
        private Vector3 startPosition;

        public void Awake() {
            startPosition = transform.localPosition;
        }        

        public void SetSize(float sizePercent, float parentSize) {
            RectTransform rt = GetComponent<RectTransform>();
            Vector2 size = rt.sizeDelta;

            size.x = size.y = sizePercent * parentSize;

            rt.sizeDelta = size;
        }

        //Needed in order to get a proper reading for OnPointerUp
        public void OnPointerDown(PointerEventData eventData) {}

        public void OnPointerUp(PointerEventData eventData) {
            transform.localPosition = startPosition;
        }

        public void OnDrag(PointerEventData eventData) {
            transform.position = eventData.position;
        }
    }
}
