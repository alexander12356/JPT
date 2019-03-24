using JPT.Gameplay.AttackClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance { get; set; } = null;

    [SerializeField] private Damageable m_PlayerDamageable = null;
    [SerializeField] private string m_CurrentScene;

    public bool IsPlayerDeath { get; set; } = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        m_PlayerDamageable.OnDeath += () => IsPlayerDeath = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(m_CurrentScene);
    }
}
