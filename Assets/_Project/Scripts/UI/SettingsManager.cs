using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    public Toggle fullscreenToggle;

    // ---------------- AUDIO ----------------

    public void SetMasterVolume(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat("MasterVolume", value);
    }

    public void SetMusicVolume(float value) // DA COLLEGARE L'AUDIO MANAGER 
    {
        PlayerPrefs.SetFloat("MusicVolume", value); 
    }

    public void SetSFXVolume(float value)
    {
        PlayerPrefs.SetFloat("SFXVolume", value); // DA COLLEGARE SFX
    }

    // ---------------- VIDEO ----------------

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
    }

    // ---------------- LOAD SETTINGS ----------------

    private void Start()
    {
        // MASTER
        float master = PlayerPrefs.GetFloat("MasterVolume", 1f);
        masterSlider.value = master;
        AudioListener.volume = master;

        // MUSIC
        float music = PlayerPrefs.GetFloat("MusicVolume", 1f);
        musicSlider.value = music;

        // SFX
        float sfx = PlayerPrefs.GetFloat("SFXVolume", 1f);
        sfxSlider.value = sfx;

        // FULLSCREEN
        bool full = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
        fullscreenToggle.isOn = full;
        Screen.fullScreen = full;
    }
}