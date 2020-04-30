using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JPT.Gameplay.AttackClasses;

namespace JPT.Gameplay
{
    public class PunchForce : MonoBehaviour
    {
        [SerializeField] private float m_Force = 0f;

        public void AddForce(Damager sender, Damageable target)
        {
            var targetRigidBody = target.GetComponent<Rigidbody2D>();
            if (targetRigidBody != null)
            {
                targetRigidBody.bodyType = RigidbodyType2D.Dynamic;
                targetRigidBody.AddForce((target.transform.position - sender.transform.position).normalized * m_Force);
            }
        }
    }
}