using System;

using UnityEngine;
using UnityEngine.Events;

using UnityStandardAssets.CrossPlatformInput;

namespace JPT.Gameplay.PlayerClasses
{
    public class PlayerInputController : MonoBehaviour
    {
        [Serializable]
        public class HorizontalInputEvent : UnityEvent<float> { }

        [SerializeField] private HorizontalInputEvent m_HorizontalInputEvent = null;
        [SerializeField] private UnityEvent m_JumpInputEvent = null;

        private void Update()
        {
            var axisValue = CrossPlatformInputManager.GetAxis("Horizontal");

            m_HorizontalInputEvent?.Invoke(axisValue);

            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                m_JumpInputEvent.Invoke();
                Debug.Log("GAME_LOG: Pushed jump button");
            }
        }
    }
}