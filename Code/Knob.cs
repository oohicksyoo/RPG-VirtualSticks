using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RPG.VirtualSticks {
    public class Knob : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler {

        private Touch currentTouch;
        private Vector3 startPosition;
        private RectTransform rectTransform;

        public void Awake() {
            rectTransform = GetComponent<RectTransform>();
            startPosition = rectTransform.anchoredPosition;
        }        

        public void SetSize(float sizePercent, float parentSize) {            
            Vector2 size = rectTransform.sizeDelta;
            size.x = size.y = sizePercent * parentSize;
            rectTransform.sizeDelta = size;
        }

        //Needed in order to get a proper reading for OnPointerUp
        public void OnPointerDown(PointerEventData eventData) {}

        public void OnPointerUp(PointerEventData eventData) {
            rectTransform.anchoredPosition = startPosition;
        }

        public void OnDrag(PointerEventData eventData) {
            transform.position = eventData.position;
        }
    }
}
