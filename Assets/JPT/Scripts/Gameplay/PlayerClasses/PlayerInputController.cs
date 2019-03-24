using JPT.Gameplay.AttackClasses;
using System;

using UnityEngine;
using UnityEngine.Events;

using UnityStandardAssets.CrossPlatformInput;

namespace JPT.Gameplay.PlayerClasses
{
    public class PlayerInputController : MonoBehaviour
    {
        [Serializable] public class HorizontalInputEvent : UnityEvent<float> { }

        private Damageable m_Damageable = null;

        [SerializeField] private HorizontalInputEvent m_HorizontalInputEvent = null;
        [SerializeField] private UnityEvent m_JumpInputEvent = null;
        [SerializeField] private UnityEvent m_FireInputEvent = null;
        [SerializeField] private UnityEvent m_TakeInputEvent = null;

        private void Awake()
        {
            m_Damageable = GetComponent<Damageable>();
        }

        private void Update()
        {
            var axisValue = 0f;

            if (!m_Damageable.IsDeath)
            {
                axisValue = CrossPlatformInputManager.GetAxis("Horizontal");

                if (CrossPlatformInputManager.GetButtonDown("Fire1"))
                {
                    m_FireInputEvent.Invoke();
                }

                if (CrossPlatformInputManager.GetButtonDown("Fire2"))
                {
                    m_TakeInputEvent?.Invoke();
                }

                if (CrossPlatformInputManager.GetButtonDown("Jump"))
                {
                    m_JumpInputEvent.Invoke();
                }
            }

            m_HorizontalInputEvent?.Invoke(axisValue);
        }
    }
}