using System;

using UnityEngine;

using JPT.Core;

namespace JPT.Gameplay.BasicActions
{
    public class TriggerEnterDetection : MonoBehaviour
    {
        [SerializeField] private string[] m_CanDetectionTags = null;

        [SerializeField] private Collider2dUnityEvent m_OnTriggedEnter = null;
        [SerializeField] private Collider2dUnityEvent m_OnTriggedExit = null;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (Array.Exists(m_CanDetectionTags, (item) => collision.CompareTag(item)))
            {
                m_OnTriggedEnter?.Invoke(collision);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (Array.Exists(m_CanDetectionTags, (item) => collision.CompareTag(item)))
            {
                m_OnTriggedExit?.Invoke(collision);
            }
        }
    }
}