using JPT.Gameplay.AttackClasses;
using UnityEngine;

namespace JPT.Gameplay.PlayerClasses
{
    public class PlayerViewController : MonoBehaviour
    {
        [SerializeField] private Transform m_TakenObjectPlace = null;
        [SerializeField] private Animator m_Animator = null;
        [SerializeField] private Damageable m_Damageable = null;

        private void Awake()
        {
            m_Animator = GetComponent<Animator>();
            m_Damageable = GetComponent<Damageable>();
        }

        private void Start()
        {
            m_Damageable.OnDeath += PlayDeath;
        }

        public void SetTakenObject(Collider2D collider2D)
        {
            var takenObjectTransform = collider2D.transform;
            takenObjectTransform.SetParent(m_TakenObjectPlace);
            takenObjectTransform.localPosition = Vector3.zero;
        }

        public void PlayDeath()
        {
            m_Animator.SetTrigger("Death");
        }
    }
}