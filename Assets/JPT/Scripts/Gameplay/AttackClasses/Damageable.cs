using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JPT.Gameplay.AttackClasses
{
    public class Damageable : MonoBehaviour
    {
        [SerializeField] private float m_Health = 1f;

        public void Damage(float value)
        {
            m_Health -= value;
            if (m_Health > 0)
            {
                return;
            }

            Destroy(gameObject);
        }
    }
}