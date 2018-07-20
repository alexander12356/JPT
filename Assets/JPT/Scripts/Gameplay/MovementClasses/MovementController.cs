using System;
using System.Collections;

using UnityEngine;
using UnityEngine.Events;

namespace JPT.Gameplay.MovementClasses
{
    [Serializable] public class BoolUnityEvent : UnityEvent<bool> { }

    public class MovementController : MonoBehaviour
    {
        private Rigidbody2D m_Rigidbody2D = null;
        private Vector2 m_Velocity = Vector2.zero;
        private bool m_IsGround = false;
        private bool m_IsPrevGround = false;
        private bool m_IsJump = false;

        [SerializeField] private float m_Speed = 0f;
        [SerializeField] private float m_JumpForce = 0f;
        [SerializeField] private bool m_InfinityJump = false;
        [SerializeField] private BoolUnityEvent m_OnMoving = null;
        [SerializeField] private BoolUnityEvent m_OnJumping = null;
        [SerializeField] private UnityEvent m_OnLanding = null;

        [Space]
        [SerializeField] private LayerMask m_GroundMask = -1;
        [SerializeField] private CircleCollider2D m_CheckGroundSettings = null;

        private void Awake()
        {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void MoveHorizontal(float value)
        {
            m_Velocity = new Vector2(value * m_Speed, m_Rigidbody2D.velocity.y);

            if (value < 0)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            if (value > 0)
            {
                transform.localScale = Vector3.one;
            }

            m_OnMoving?.Invoke(value != 0.0f);
        }

        public void Jump()
        {
            m_IsJump = true;
        }

        public void FixedUpdate()
        {
            m_IsGround = Physics2D.OverlapCircle(m_CheckGroundSettings.transform.position, m_CheckGroundSettings.radius, m_GroundMask);

            if (m_IsGround && m_IsPrevGround)
            {
                m_OnLanding?.Invoke();
            }

            m_Rigidbody2D.velocity = m_Velocity;

            if (m_IsJump)
            {
                m_IsJump = false;
                if (m_InfinityJump || m_IsGround)
                {
                    m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, 0.0f);
                    m_Rigidbody2D.AddForce(Vector2.up * m_JumpForce, ForceMode2D.Force);
                }
            }

            m_IsPrevGround = m_IsGround;
        }

        public void Update()
        {
            m_OnJumping?.Invoke(!m_IsGround);
        }
    }
}