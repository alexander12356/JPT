using System;

using UnityEngine;

namespace JPT.Gameplay.AttackClasses
{
    public class BaseDamageableDetector : MonoBehaviour
    {
        private Collider2D[] m_AttackedTargetsArray = null;

        [SerializeField] private CircleCollider2D m_Settings = null;
        [SerializeField] private LayerMask m_TargetLayers = -1;
        [SerializeField] private string[] m_TargetsTag = null;

        private void Awake()
        {
            m_AttackedTargetsArray = new Collider2D[20];
        }

        public Damageable[] DetectDamageable()
        {
            var targetsCount = Physics2D.OverlapCircleNonAlloc(m_Settings.transform.position, m_Settings.radius, m_AttackedTargetsArray, m_TargetLayers);

            var result = new Damageable[20];
            var damageableCounter = 0;

            for (int i = 0; i < targetsCount; i++)
            {
                for (int j = 0; j < m_TargetsTag.Length; j++)
                {
                    if (m_AttackedTargetsArray[i].CompareTag(m_TargetsTag[j]))
                    {
                        result[damageableCounter++] = m_AttackedTargetsArray[i].GetComponent<Damageable>();
                    }
                }
            }

            Array.Resize(ref result, damageableCounter);

            return result;
        }
    }
}