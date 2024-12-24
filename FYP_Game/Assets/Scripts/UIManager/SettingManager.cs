using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public Slider graphicsSlider;
    public Slider soundSlider;
    public Slider musicSlider;

    private void Start()
    {
        // Load saved settings or default values
        graphicsSlider.value = PlayerPrefs.GetFloat("Graphics", 1);
        soundSlider.value = PlayerPrefs.GetFloat("Sound", 1);
        musicSlider.value = PlayerPrefs.GetFloat("Music", 1);

        // Apply saved settings
        ApplySettings();
    }

    public void OnGraphicsChanged(float value)
    {
        PlayerPrefs.SetFloat("Graphics", value);
        ApplySettings();
    }

    public void OnSoundChanged(float value)
    {
        PlayerPrefs.SetFloat("Sound", value);
    }

    public void OnMusicChanged(float value)
    {
        PlayerPrefs.SetFloat("Music", value);
    }

    private void ApplySettings()
    {
        QualitySettings.SetQualityLevel(Mathf.RoundToInt(graphicsSlider.value * 5));
    }
}
