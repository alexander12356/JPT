using UnityEngine;

namespace JPT.Gameplay.EnemyClasses.ShootClasses
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float m_Speed = 0f;
        [SerializeField] private float m_LifeTime = 0f;

        public Vector3 Direction { get; set; }

        private void Start()
        {
            Destroy(gameObject, m_LifeTime);
        }

        public void Update()
        {
            transform.position += m_Speed * Direction * Time.deltaTime;
        }
    }
}