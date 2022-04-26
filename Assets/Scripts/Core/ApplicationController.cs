using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Default Config
    public static bool IsFirstRun() {
        if (PlayerPrefs.GetString("FirstTime") != "Caste") {
            return true;
        }
        return false;
    }

    public static void SetDefaultConfigs() {
        PlayerPrefs.SetString("FirstTime", "Caste");
        EnableSoundFX();
        SetVolumeSFX(1);
        EnableMusic();
        SetVolumeMusic(1);
    }

    // Sound Config
    // SFX
    public static void EnableSoundFX() {
        PlayerPrefs.SetInt("SFXSound", 1);
    }

    public static void DisableSoundFX() {
        PlayerPrefs.SetInt("SFXSound", 0);

    }

    public static bool IsMutedSFX() {
        if (PlayerPrefs.GetInt("SFXSound") == 1) {
            return false;
        }
        return true;
    }

    public static float GetVolumeSFX() {
        return PlayerPrefs.GetFloat("SFXSoundVolume");
    }

    public static void SetVolumeSFX(float vol) {
        PlayerPrefs.SetFloat("SFXSoundVolume", vol);
    }

    // Music
    public static void EnableMusic() {
        PlayerPrefs.SetInt("MusicSound", 1);
    }

    public static void DisableMusic() {
        PlayerPrefs.SetInt("MusicSound", 0);
    }

    public static bool IsMutedMusic() {
        if (PlayerPrefs.GetInt("MusicSound") == 1) {
            return false;
        }
        return true;
    }

    public static float GetVolumeMusic() {
        return PlayerPrefs.GetFloat("MusicSoundVolume");
    }

    public static void SetVolumeMusic(float vol) {
        PlayerPrefs.SetFloat("MusicSoundVolume", vol);        
    }

    // Quit
    public static void ExitGame() {
        Application.Quit();
    }
}
