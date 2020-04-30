using JPT.Gameplay.AttackClasses;
using System;

using UnityEngine;
using UnityEngine.Events;

namespace JPT.Core
{
    [Serializable] public class Collider2dUnityEvent : UnityEvent<Collider2D> { }
    [Serializable] public class DamageableUnityEvent : UnityEvent<Damageable> { }
}