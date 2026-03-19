using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    public AudioSource musicSource;
    // eventualmente aggiungere un array/list di SFX AudioSource in futuro

    public Toggle fullscreenToggle;

    // ---------------- AUDIO ----------------

    // Controlla tutto l'audio
    public void SetMasterVolume(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat("MasterVolume", value);
    }

    // Controlla solo la musica
    public void SetMusicVolume(float value)
    {
        if (musicSource != null)
            musicSource.volume = value;
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    // Controlla solo SFX (da collegare agli AudioSource dei suoni)
    public void SetSFXVolume(float value)
    {
        // provare un foreach su tutti gli AudioSource SFX
        // foreach(var sfx in sfxSources) sfx.volume = value;  //DA CAPIRE COME IMPLEMENTARE
        PlayerPrefs.SetFloat("SFXVolume", value);
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
        if (musicSource != null)
            musicSource.volume = music;

        // SFX
        float sfx = PlayerPrefs.GetFloat("SFXVolume", 1f);
        sfxSlider.value = sfx;

        // FULLSCREEN
        bool full = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
        fullscreenToggle.isOn = full;
        Screen.fullScreen = full;
    }
}