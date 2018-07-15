using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JPT.Gameplay.AttackClasses;


namespace JPT.Gameplay
{
    public class DamageByCollided : MonoBehaviour
    {
        [SerializeField] private float m_DamageValue = 1f;
        [SerializeField] private Damageable m_Damageable = null;

        public bool CanDamaged { get; set; } = true;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (CanDamaged)
            {
                m_Damageable?.Damage(null, m_DamageValue);
            }
        }
    }
}