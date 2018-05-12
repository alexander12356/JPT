using UnityEngine;

namespace JPT.Gameplay.PlayerClasses
{
    public class PlayerViewController : MonoBehaviour
    {
        [SerializeField] private Transform m_TakenObjectPlace = null;

        public void SetTakenObject(Collider2D collider2D)
        {
            var takenObjectTransform = collider2D.transform;
            takenObjectTransform.SetParent(m_TakenObjectPlace);
            takenObjectTransform.localPosition = Vector3.zero;
        }
    }
}