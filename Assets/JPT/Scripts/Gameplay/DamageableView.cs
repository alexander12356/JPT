using JPT.Gameplay.AttackClasses;
using UnityEngine;

public class DamageableView : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Damageable>().OnDamaged += OnDamaged;
    }

    private void OnDamaged()
    {
        GetComponent<Animator>().SetTrigger("Damaged");
    }
}
