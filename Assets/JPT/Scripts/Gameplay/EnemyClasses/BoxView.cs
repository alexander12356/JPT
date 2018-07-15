using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JPT.Gameplay.AttackClasses;

namespace JPT.Gameplay.EnemyClasses.Box
{
    public class BoxView : MonoBehaviour
    {
        private Animator m_Animator = null;

        [SerializeField] private float m_TimeBeforeDestroy = 1f;

        private void Awake()
        {
            m_Animator = GetComponent<Animator>();
        }

        public void Destroying(Damager sender, Damageable target)
        {
            m_Animator.SetTrigger("Destroy");
            Destroy(gameObject, m_TimeBeforeDestroy);
        }
    }
}