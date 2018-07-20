using UnityEngine;

namespace JPT.Gameplay.ViewClasses
{ 
    public class PlayerAnimationController : MonoBehaviour
    {
        private Animator m_Animator = null;

        private void Awake()
        {
            m_Animator = GetComponent<Animator>();
        }

        public void PlayMovingAnimation(bool isMoving)
        {
            m_Animator.SetBool("Moving", isMoving);
        }

        public void PlayJumpAnimation(bool isJumping)
        {
            m_Animator.SetBool("Jumping", isJumping);
        }

        public void PlayPunchAnimation()
        {
            m_Animator.SetTrigger("Punch");
        }
    }
}