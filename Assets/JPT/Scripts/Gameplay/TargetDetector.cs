using JPT.Core;
using JPT.Gameplay.AttackClasses;
using UnityEngine;

public class TargetDetector : MonoBehaviour
{
    [SerializeField] private string[] m_TargetTags;
    [SerializeField] private DamageableUnityEvent m_OnTriggered = null;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var targetTag in m_TargetTags)
        {
            if (collision.CompareTag(targetTag))
            {
                m_OnTriggered?.Invoke(collision.GetComponent<Damageable>());
            }
        }
    }
}
