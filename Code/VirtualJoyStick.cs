﻿using System;
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
        [SerializeField]
        [Range(0.1f, 0.9f)]
        private float knobSizePercent = 0.48f;

        [Header("Children")]
        [SerializeField]
        private Knob knob;

        [Header("Events")]
        [SerializeField]
        private JoystickEventAxis joystickEventAxis;
        [SerializeField]
        private JoystickEventAngle joystickEventAngle;
        [SerializeField] 
        private JoystickEventActive joystickEventActive;

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

        public JoystickEventActive JoystickEventActive
        {
            get => joystickEventActive;
            set => joystickEventActive = value;
        }

        public bool IsActive {
            get {
                return knob.IsDown;
            }
        }
        #endregion

        private Vector3 currentAxis;
        private float currentAngle;
        private float size;
        private float requiredDistance;

        public void Start() {
            size = GetComponent<RectTransform>().sizeDelta.x;
            requiredDistance = knobDistance * (size * 0.5f) * knobSizePercent;

            currentAxis = Vector3.zero;
            currentAngle = 0;

            knob.SetSize(knobSizePercent, size);

            knob.IsActiveEvent += (value) => {
                joystickEventActive.Invoke(value);
            };
        }

        public void Update() {

            var direction = knob.transform.position - transform.position;
            direction.Normalize();

            var distance = Vector3.Distance(knob.transform.position, transform.position);

            //Only allow the knob to go so far
            if (distance > requiredDistance) {
                distance = requiredDistance;
                knob.transform.position = transform.position + (direction * requiredDistance);
            }   

            //Determine what event to fire
            if (joystickType == JoystickType.Axis) {
                if (updateType == UpdateType.OnlyOnChange && currentAxis == direction) return;
                currentAxis = direction;
                joystickEventAxis.Invoke(direction);
            } else if (joystickType == JoystickType.Angle) {
                float angle = Vector2.Angle(Vector2.up, direction);
                angle = (direction.x < 0) ? 360 - angle : angle;// Check for angle when direction x is on the left sided
                if (!knob.IsDown && updateType == UpdateType.OnlyOnChange) return;
                if (updateType == UpdateType.OnlyOnChange && currentAngle == angle) return;
                currentAngle = angle;
                joystickEventAngle.Invoke(angle);
            }
        }
    }

    [Serializable]
    public class JoystickEventAxis : UnityEvent<Vector2> {}
    [Serializable]
    public class JoystickEventAngle : UnityEvent<float> { }
    [Serializable]
    public class JoystickEventActive : UnityEvent<bool> { }
    public enum JoystickType {
        Axis = 0,
        Angle
    }

    public enum UpdateType {
        PerFrame = 0,
        OnlyOnChange
    }
}
