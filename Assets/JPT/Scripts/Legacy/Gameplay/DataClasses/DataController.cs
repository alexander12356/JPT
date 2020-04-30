using System;
using UnityEngine;

namespace JPT.Gameplay.DataClasses
{
    public class DataController : MonoBehaviour
    {
        [SerializeField] public ScriptableObject m_Data;

        public Action<ScriptableObject> OnDataChanged { get; set; } = null;
            
        public void Awake()
        {
            m_Data = Instantiate(m_Data);
        }

        public void Flush(Action<ScriptableObject> dataChanged)
        {
            dataChanged?.Invoke(m_Data);
        }
    }
}