using System;
using UnityEngine;

using JPT.Gameplay.DataClasses;

namespace JPT.Gameplay.AttackClasses
{
    public class Damageable : MonoBehaviour
    {
        [SerializeField] private float m_Health = 1f;
        [SerializeField] private AttackedUnityEvent m_OnDeath = null;
        [SerializeField] private bool m_IsGodMode = false;

        public event Action OnDamaged;
        public bool IsDeath { get; set; } = false;
        public event Action OnDeath;

        public void Start()
        {
            GetComponent<DataController>()?.OnDataChanged.Subscribe(DataChanged);
            GetComponent<DataController>()?.Flush(DataChanged);
        }

        private void DataChanged(ScriptableObject data)
        {
            m_Health = ((IHealth)data).Health;
        }

        public void Damage(Damager sender, float value)
        {
            if (m_IsGodMode || IsDeath)
            {
                return;
            }

            m_Health -= value;
            if (m_Health > 0)
            {
                OnDamaged?.SafetyInvoke();
                return;
            }

            m_OnDeath?.Invoke(sender, this);
            OnDeath?.Invoke();
            IsDeath = true;
        }
    }
}