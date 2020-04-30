using UnityEngine;

using JPT.Gameplay.AttackClasses;
using JPT.Gameplay.TakeObjectClasses;

namespace JPT.Gameplay.PlayerClasses
{
    public class PlayerAttackerController : MonoBehaviour
    {
        [SerializeField] private Damager m_Damager = null;
        [SerializeField] private TakeObjectController m_TakeObjectController = null;

        public void TryAttack()
        {
            if (m_TakeObjectController.IsTaken)
            {
                m_TakeObjectController.Throw();
            }
            else
            {
                m_Damager.Attack();
            }
        }
    }
}