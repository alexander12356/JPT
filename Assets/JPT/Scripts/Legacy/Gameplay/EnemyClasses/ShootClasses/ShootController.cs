using System.Collections;

using UnityEngine;

namespace JPT.Gameplay.EnemyClasses.ShootClasses
{
    public class ShootController : MonoBehaviour
    {
        private Collider2D m_DetectedObject = null;
        private float m_ElapsedTime = 0f;

        [SerializeField] private Projectile m_ProjectilePrefab = null;
        [SerializeField] private float m_ShootDelay = 0f;

        public Collider2D DetectedCollider
        {
            get
            {
                return m_DetectedObject;
            }
            set
            {
                m_DetectedObject = value;
            }
        }

        public void RemoveDetectedObject()
        {
            DetectedCollider = null;
        }

        private void Update()
        {
            if (DetectedCollider == null)
            {
                if (m_ElapsedTime <= m_ShootDelay)
                {
                    m_ElapsedTime += Time.deltaTime;
                }
                return;
            }

            if (m_ElapsedTime >= m_ShootDelay)
            {
                var projectile = Instantiate(m_ProjectilePrefab);
                projectile.transform.position = transform.position;
                projectile.Direction = (DetectedCollider.gameObject.transform.position - transform.position).normalized;
                m_ElapsedTime -= m_ShootDelay;
            }
            else
            {
                m_ElapsedTime += Time.deltaTime;
            }
        }
    }
}