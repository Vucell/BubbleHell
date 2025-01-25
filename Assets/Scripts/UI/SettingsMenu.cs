using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    //public int quality;
    public float volume = 0.7f;
    [SerializeField] private Slider qualitySlider;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioMixer audioMixer;

    private void Start()
    {
        RefreshSettings();
    }

    public void RefreshSettings()
    {
        //qualitySlider.value = quality;
        volumeSlider.value = volume;

        Apply();
        
    }

    public void Apply()
    {
        //quality = (int)qualitySlider.value;
        volume = volumeSlider.value;

        //QualitySettings.SetQualityLevel(quality);
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);

        //Debug.Log("Quality " + qualitySlider.value);
        Debug.Log("Volume " + volumeSlider.value);

        //Debug.Log("Quality set " + quality);
        Debug.Log("Volume set " + volume);
    }

}
