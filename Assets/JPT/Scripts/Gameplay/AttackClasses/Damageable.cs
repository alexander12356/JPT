using UnityEngine;

namespace JPT.Gameplay.AttackClasses
{
    public class Damageable : MonoBehaviour
    {
        [SerializeField] private float m_Health = 1f;
        [SerializeField] private AttackedUnityEvent m_OnDeath = null;

        public void Damage(Damager sender, float value)
        {
            m_Health -= value;
            if (m_Health > 0)
            {
                return;
            }

            m_OnDeath?.Invoke(sender, this);
        }
    }
}