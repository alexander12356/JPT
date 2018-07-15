using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JPT.Gameplay.AttackClasses;

namespace JPT.Gameplay
{
    public class ActivateToDestroyable : MonoBehaviour
    {
        public void Activate(Damager sender, Damageable target)
        {
            target.GetComponent<DamageByCollided>().CanDamaged = true;
        }
    }
}