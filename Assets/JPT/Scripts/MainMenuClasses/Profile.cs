using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JPT
{
    public class Profile : MonoBehaviour
    {
        public static Profile Instance { private set; get; }

        [SerializeField] private ProfileData m_DefaultProfileData = null;

        public ProfileData Data = null;
        

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            InitializeLevels();
        }

        private void OnDestroy()
        {
            PlayerPrefs.SetString("Profile", Data.Serialize());
        }

        private void InitializeLevels()
        {
            if (!PlayerPrefs.HasKey("Profile"))
            {
                PlayerPrefs.SetString("Profile", m_DefaultProfileData.Serialize());
            }

            Data = PlayerPrefs.GetString("Profile").Deserialize<ProfileData>();
        }

        public void UnlockLevel(string newLevelId)
        {
            if (!Data.OpenedLevels.Exists(levelId => levelId == newLevelId))
            {
                Data.OpenedLevels.Add(newLevelId);
            }
        }
    }
}