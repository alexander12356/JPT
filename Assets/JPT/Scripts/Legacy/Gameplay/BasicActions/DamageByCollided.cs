using System;
using UnityEngine;

using JPT.Gameplay.AttackClasses;


namespace JPT.Gameplay
{
    public class DamageByCollided : MonoBehaviour
    {
        [SerializeField] private float m_DamageValue = 1f;
        [SerializeField] private Damageable m_Damageable = null;
        [SerializeField] private string[] m_IgnoredObjectTags = null;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!Array.Exists(m_IgnoredObjectTags, (item) => collision.gameObject.CompareTag(item)))
            {
                m_Damageable?.Damage(null, m_DamageValue);
            }
        }
    }
}