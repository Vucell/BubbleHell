using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public Settings Settings;
    [SerializeField] private Slider qualitySlider;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioMixer audioMixer;

    private void Start()
    {
        RefreshSettings();
    }

    public void RefreshSettings()
    {
        qualitySlider.value = Settings.quality;
        volumeSlider.value = Settings.volume;

        Apply();
    }

    public void Apply()
    {
        Settings.quality = (int)qualitySlider.value;
        Settings.volume = volumeSlider.value;

        QualitySettings.SetQualityLevel(Settings.quality);
        audioMixer.SetFloat("Master", Mathf.Log10(Settings.volume) * 20);
    }

}
