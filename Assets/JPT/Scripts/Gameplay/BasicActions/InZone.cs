using System;

using UnityEngine;
using UnityEngine.Events;

namespace JPT.Gameplay
{
    [Serializable] public class InZoneUnityEvent : UnityEvent<Collider2D> { }
    

    public class InZone : MonoBehaviour
    {
        [SerializeField] private LayerMask m_CantPushingLayers;
        [SerializeField] private string[] m_CantPushingTags;

        [Space]
        [SerializeField] private UnityEvent m_OnTriggerEnter = null;
        [SerializeField] private UnityEvent m_OnTriggetExit = null;
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if ((m_CantPushingLayers.value & 1 << collision.gameObject.layer) > 0)
            {
                m_OnTriggerEnter?.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if ((m_CantPushingLayers.value & 1 << collision.gameObject.layer) > 0)
            {
                m_OnTriggetExit?.Invoke();
            }
        }
    }
}