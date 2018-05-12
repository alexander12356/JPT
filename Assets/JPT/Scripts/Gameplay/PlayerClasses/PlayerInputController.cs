using System;

using UnityEngine;
using UnityEngine.Events;

using UnityStandardAssets.CrossPlatformInput;

namespace JPT.Gameplay.PlayerClasses
{
    public class PlayerInputController : MonoBehaviour
    {
        [Serializable] public class HorizontalInputEvent : UnityEvent<float> { }

        [SerializeField] private HorizontalInputEvent m_HorizontalInputEvent = null;
        [SerializeField] private UnityEvent m_JumpInputEvent = null;
        [SerializeField] private UnityEvent m_FireInputEvent = null;
        [SerializeField] private UnityEvent m_TakeInputEvent = null;

        private void Update()
        {
            var axisValue = CrossPlatformInputManager.GetAxis("Horizontal");

            m_HorizontalInputEvent?.Invoke(axisValue);

            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                m_JumpInputEvent.Invoke();
                Debug.Log("GAME_LOG: Pushed jump button");
            }

            if (CrossPlatformInputManager.GetButtonDown("Fire1"))
            {
                m_FireInputEvent.Invoke();
                print("GAME_LOG: Pushed fire1 button");
            }

            if (CrossPlatformInputManager.GetButtonDown("Fire2"))
            {
                m_TakeInputEvent?.Invoke();
                print("GAME+LOG: Take fire2 button");
            }
        }
    }
}