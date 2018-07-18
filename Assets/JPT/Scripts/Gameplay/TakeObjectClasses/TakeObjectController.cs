using System;

using UnityEngine;
using UnityEngine.Events;

namespace JPT.Gameplay.TakeObjectClasses
{
    public class TakeObjectController : MonoBehaviour
    {
        [Serializable] public class TakenEvent : UnityEvent<Collider2D> { }

        private Collider2D[] m_TakenObjects = null;

        [SerializeField] private bool m_IsTaken = false;
        [SerializeField] private TakenEvent m_TakenEvent = null;
        [SerializeField] private Vector2 m_ThrowForce = Vector2.zero;

        [Space]
        [SerializeField] private CircleCollider2D m_Settings = null;

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

        private void Awake()
        {
            m_TakenObjects = new Collider2D[10];
        }

        public void TryTake()
        {
            if (m_IsTaken)
            {
                Throw();
                return;
            }

            Physics2D.OverlapCircleNonAlloc(m_Settings.gameObject.transform.position, m_Settings.radius, m_TakenObjects, m_Mask);
            Array.Sort(m_TakenObjects, (x, y) =>
            {
                if (!x || !y)
                {
                    return 0;
                }
                return x.transform.position.y.CompareTo(y.transform.position.y) * -1;
            });

            if (m_TakenObjects[0] != null)
            {
                for (int i = 0; i < m_CanTakeTags.Length; i++)
                {
                    if (!m_TakenObjects[0].CompareTag(m_CanTakeTags[i]))
                    {
                        continue;
                    }

                    var origin = m_TakenObjects[0].bounds.center + (Vector3.up * m_TakenObjects[0].bounds.size.y / 2) + (Vector3.up * 0.05f);
                    var raycastHit2D = Physics2D.Raycast(origin, Vector2.up, 1f, m_Mask);

                    print(raycastHit2D.collider?.gameObject.name);
                    if (raycastHit2D)
                    {
                        continue;
                    }

                    m_IsTaken = true;
                    m_TakenEvent?.Invoke(m_TakenObjects[0]);

                    m_TakenObjects[0].enabled = false;
                    m_TakenObjects[0].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                    m_TakenObjects[0].transform.eulerAngles = Vector3.zero;
                    break;
                }
            }
        }

        public void Throw()
        {
            m_TakenObjects[0].transform.SetParent(null);
            m_TakenObjects[0].enabled = true;

            var takenObjectRigidBody = m_TakenObjects[0].GetComponent<Rigidbody2D>();

            takenObjectRigidBody.bodyType = RigidbodyType2D.Dynamic;
            takenObjectRigidBody?.AddForce(transform.localScale.x * m_ThrowForce);

            m_TakenObjects[0] = null;
            m_IsTaken = false;
        }
    }
}