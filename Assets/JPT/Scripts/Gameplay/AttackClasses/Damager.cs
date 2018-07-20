using System;

using UnityEngine;
using UnityEngine.Events;

namespace JPT.Gameplay.AttackClasses
{
    [Serializable] public class AttackedUnityEvent : UnityEvent<Damager, Damageable> { }

    public class Damager : MonoBehaviour
    {
        private Damageable[] m_AttackedTargets = null;
        private BaseDamageableDetector m_DetectDamageableController = null;

        [SerializeField] private float m_AttackValue = 1f;
        [SerializeField] private AttackedUnityEvent m_OnHit = null;
        [SerializeField] private UnityEvent m_OnAttack = null;

        private void Awake()
        {
            m_DetectDamageableController = GetComponent<BaseDamageableDetector>();
        }

        public void Attack()
        {
            m_AttackedTargets = m_DetectDamageableController.DetectDamageable();
            m_OnAttack?.Invoke();
            for (int i = 0; i < m_AttackedTargets.Length; i++)
            {
                m_AttackedTargets[i].Damage(this, m_AttackValue);
                m_OnHit?.Invoke(this, m_AttackedTargets[i]);
            }
        }
    }
}