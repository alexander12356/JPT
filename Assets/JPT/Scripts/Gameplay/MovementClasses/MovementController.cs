﻿using UnityEngine;

namespace JPT.Gameplay.MovementClasses
{
    public class MovementController : MonoBehaviour
    {
        private Rigidbody2D m_Rigidbody2D = null;
        private Vector2 m_Velocity = Vector2.zero;

        [SerializeField] private float m_Speed = 0f;
        [SerializeField] private float m_JumpForce = 0f;
        [SerializeField] private bool m_InfinityJump = false;

        [Space]
        [SerializeField] private LayerMask m_GroundMask = -1;
        [SerializeField] private CircleCollider2D m_CheckGroundSettings = null;

        private void Awake()
        {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void MoveHorizontal(float value)
        {
            m_Velocity = new Vector2(value * m_Speed * Time.fixedDeltaTime, m_Rigidbody2D.velocity.y);

            if (value < 0)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            if (value > 0)
            {
                transform.localScale = Vector3.one;
            }
        }

        public void Jump()
        {
            var overlappedCollider = Physics2D.OverlapCircle(m_CheckGroundSettings.transform.position, m_CheckGroundSettings.radius, m_GroundMask);
            if (!m_InfinityJump && !overlappedCollider)
            {
                return;
            }

            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, 0.0f);
            m_Rigidbody2D.AddForce(Vector2.up * m_JumpForce, ForceMode2D.Force);
        }

        public void FixedUpdate()
        {
            m_Rigidbody2D.velocity = m_Velocity;
        }
    }
}