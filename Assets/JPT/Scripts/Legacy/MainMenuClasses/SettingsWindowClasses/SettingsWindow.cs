using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

using TMPro;

namespace JPT.UI.MainMenuClasses.SettingsWindowClasses
{
    public class SettingsWindow : MonoBehaviour
    {
        [SerializeField]
        private Slider m_MusicSlider = null;
        [SerializeField]
        private TMP_Dropdown m_ResolutionDropdown = null;
        [SerializeField]
        private AudioMixer m_AudioMixer = null;

        private void Awake()
        {
            for (int i = 0; i < Screen.resolutions.Length; i++)
            {
                m_ResolutionDropdown.options.Add(new TMP_Dropdown.OptionData(Screen.resolutions[i].ToString()));
            }
            m_ResolutionDropdown.captionText.text = m_ResolutionDropdown.options[m_ResolutionDropdown.value].text;
        }
        
        // Called from UI

        public void OnChangeMusicSlider(float value)
        {
            value = 80 * value - 80;
            m_AudioMixer.SetFloat("MusicVolume", value);
        }

        public void OnChangeSoundSlider(float value)
        {
            value = 80 * value - 80;
            m_AudioMixer.SetFloat("SoundVolume", value);
        }

        public void ChangeResolution(int value)
        {
            Screen.SetResolution(Screen.resolutions[value].width, Screen.resolutions[value].height, true);
        }
    }
}