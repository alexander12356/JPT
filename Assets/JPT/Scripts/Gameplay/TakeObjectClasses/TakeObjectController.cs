using System;

using UnityEngine;
using UnityEngine.Events;

namespace JPT.Gameplay.TakeObjectClasses
{
    public class TakeObjectController : MonoBehaviour
    {
        [Serializable] public class TakenEvent : UnityEvent<Collider2D> { }

        [SerializeField] private bool m_IsTaken = false;
        [SerializeField] private Collider2D m_TakenObject = null;
        [SerializeField] private TakenEvent m_TakenEvent = null;
        [SerializeField] private Vector2 m_ThrowForce = Vector2.zero;

        [Space]
        [SerializeField] private Transform m_CheckTakenTransform = null;
        [SerializeField] private float m_Radius = 0f;

        [SerializeField] private LayerMask m_Mask = -1;
        [SerializeField] private string[] m_CanTakeTags = null;

        public bool IsTaken
        {
            get
            {
                return m_IsTaken;
            }

            set
            {
                m_IsTaken = value;
            }
        }

        public void TryTake()
        {
            if (m_IsTaken)
            {
                return;
            }

            m_TakenObject = Physics2D.OverlapCircle(m_CheckTakenTransform.position, m_Radius, m_Mask);

            if (m_TakenObject != null)
            {
                for (int i = 0; i < m_CanTakeTags.Length; i++)
                {
                    if (!m_TakenObject.CompareTag(m_CanTakeTags[i]))
                    {
                        continue;
                    }

                    

                    var origin = m_TakenObject.bounds.center + (Vector3.up * m_TakenObject.bounds.size.y / 2) + (Vector3.up * 0.05f);
                    //var dest = origin + Vector3.up;
                    //Debug.DrawLine(origin, dest, Color.yellow, 3f);

                    var raycastHit2D = Physics2D.Raycast(origin, Vector2.up, 1f);

                    print(raycastHit2D.collider?.gameObject.name);
                    if (raycastHit2D)
                    {
                        continue;
                    }

                    m_IsTaken = true;
                    m_TakenEvent?.Invoke(m_TakenObject);

                    m_TakenObject.enabled = false;
                    m_TakenObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                    m_TakenObject.transform.eulerAngles = Vector3.zero;
                    break;
                }
            }
        }

        public void Throw()
        {
            m_TakenObject.transform.SetParent(null);
            m_TakenObject.enabled = true;

            var takenObjectRigidBody = m_TakenObject.GetComponent<Rigidbody2D>();

            takenObjectRigidBody.bodyType = RigidbodyType2D.Dynamic;
            takenObjectRigidBody?.AddForce(transform.localScale.x * m_ThrowForce);

            m_TakenObject = null;
            m_IsTaken = false;
        }
    }
}