using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuController : MonoBehaviour
{

    public Toggle toggleSoundEffects;
    public Toggle toggleSoundMusic;
    public Slider sliderSoundEffects;
    public Slider sliderSoundMusic;

    // Start is called before the first frame update
    void Start()
    {
        if (ApplicationController.IsFirstRun()) {
            ApplicationController.SetDefaultConfigs();
        }

        toggleSoundEffects.isOn = !ApplicationController.IsMutedSFX();
        toggleSoundMusic.isOn = !ApplicationController.IsMutedMusic();
        sliderSoundEffects.value = ApplicationController.GetVolumeSFX();
        sliderSoundMusic.value = ApplicationController.GetVolumeMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSFX() {
        if (toggleSoundEffects.isOn) {
            ApplicationController.DisableSoundFX();
        } else {
            ApplicationController.EnableSoundFX();
        }
    }

    public void SetMusic() {
        if (toggleSoundMusic.isOn) {
            ApplicationController.DisableMusic();
        } else {
            ApplicationController.EnableMusic();
        }
    }

    public void SetSFXVolume() {
        ApplicationController.SetVolumeSFX(sliderSoundEffects.value);
    }

    public void SetMusicVolume() {
        ApplicationController.SetVolumeMusic(sliderSoundMusic.value);
    }
}
