using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RPG.VirtualSticks {
    public class VirtualJoyStick : MonoBehaviour {

        [Header("Joystick Options")]
        [SerializeField]
        private JoystickType joystickType = JoystickType.Axis;
        [SerializeField]
        private UpdateType updateType = UpdateType.PerFrame;
        [SerializeField]
        [Range(0.0f, 1.0f)]
        private float knobDistance = 1;

        [Header("Children")]
        [SerializeField]
        private Knob knob;

        [Header("Events")]
        [SerializeField]
        private JoystickEventAxis joystickEventAxis;
        [SerializeField]
        private JoystickEventAngle joystickEventAngle;

        #region Properties to access events through code
        public JoystickEventAxis JoystickEventAxis {
            get {
                return joystickEventAxis;
            }

            set {
                joystickEventAxis = value;
            }
        }

        public JoystickEventAngle JoystickEventAngle {
            get {
                return joystickEventAngle;
            }

            set {
                joystickEventAngle = value;
            }
        }
        #endregion

        private Vector2 currentAxis;
        private float currentAngle;
        private float size;
        private float requiredDistance;

        public void Start() {
            size = GetComponent<RectTransform>().sizeDelta.x;
            requiredDistance = knobDistance * (size * 0.5f);
        }

        public void Update() {
            knob.UpdateKnob();

            var direction = knob.transform.position - transform.position;
            direction.Normalize();

            var distance = Vector3.Distance(knob.transform.position, transform.position);

            if (distance > requiredDistance) {
                distance = requiredDistance;
                knob.transform.position = transform.position + (direction * requiredDistance);
            }

            direction *= distance;
        }
    }

    [Serializable]
    public class JoystickEventAxis : UnityEvent<Vector2> {}
    [Serializable]
    public class JoystickEventAngle : UnityEvent<float> { }
    public enum JoystickType {
        Axis = 0,
        Angle
    }

    public enum UpdateType {
        PerFrame = 0,
        OnlyOnChange
    }
}
