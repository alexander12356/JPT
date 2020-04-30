using System;

using UnityEngine;

namespace JPT.Gameplay.DataClasses
{
    [CreateAssetMenu(menuName = "JPT/Data/PlayerData")]
    public class PlayerData : ScriptableObject, IHealth, IDamage
    {
        [SerializeField] private float m_Health = 0f;
        [SerializeField] private float m_Damage = 0f;

        public float Health
        {
            get
            {
                return m_Health;
            }

            set
            {
                m_Health = value;
            }
        }

        public float Damage
        {
            get
            {
                return m_Damage;
            }

            set
            {
                m_Damage = value;
            }
        }
    }
}