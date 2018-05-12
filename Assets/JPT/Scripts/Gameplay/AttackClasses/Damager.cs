using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JPT.Gameplay.AttackClasses
{
    public class Damager : MonoBehaviour
    {
        private Collider2D[] m_AttackedTargetsArray = new Collider2D[20];

        [SerializeField] private float m_AttackValue = 1f;
        [SerializeField] private LayerMask m_TargetLayers = -1;
        [SerializeField] private string[] m_TargetsTag = null;

        [Space]
        [SerializeField] private Transform m_CheckAttackTransform = null;
        [SerializeField] private float m_Radius = 0f;

        public void Attack()
        {
            var targetsCount = Physics2D.OverlapCircleNonAlloc(m_CheckAttackTransform.position, m_Radius, m_AttackedTargetsArray, m_TargetLayers);
            for (int i = 0; i < targetsCount; i++)
            {
                for (int j = 0; j < m_TargetsTag.Length; j++)
                {
                    if (m_AttackedTargetsArray[i].CompareTag(m_TargetsTag[j]))
                    {
                        m_AttackedTargetsArray[i].GetComponent<Damageable>()?.Damage(m_AttackValue);
                    }
                }
            }
        }
    }
}