using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider fxVolumeSlider;

    // Start is called before the first frame update
    void Start()
    {
       
        Load();
        ChangeVolume();
        
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }
    public void ChangeFXVolume()
    {

        // Update the sound effects volume in the SettingsManager.
        Save();
    }

    private void Load()
    {
        float musicVolume = PlayerPrefs.GetFloat("musicVolume", 1.0f);
        float fxVolume = PlayerPrefs.GetFloat("fxVolume", 1.0f);

        Debug.Log("Loaded Music Volume: " + musicVolume);
        Debug.Log("Loaded FX Volume: " + fxVolume);

        volumeSlider.value = musicVolume;
        fxVolumeSlider.value = fxVolume;

    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
        PlayerPrefs.SetFloat("fxVolume", fxVolumeSlider.value);
        

    }

}
