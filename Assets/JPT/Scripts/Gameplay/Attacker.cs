using JPT.Gameplay.AttackClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Attacker : MonoBehaviour
{
    public float AttackValue = 1;
    private Damager m_Damager = null;
    public UnityEvent OnAttacked = null;

    private void Awake()
    {
        m_Damager = GetComponent<Damager>();
    }

    public void Attack(Damageable damageable)
    {
        damageable.Damage(m_Damager, 1);
        OnAttacked?.Invoke();
    }
}
