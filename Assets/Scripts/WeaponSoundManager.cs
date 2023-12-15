using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Load and apply the saved FX volume only once at the start.
        float fxVolume = PlayerPrefs.GetFloat("fxVolume", 1.0f); // Default to 1.0f if not set
        audioSource.volume = fxVolume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayWeaponFireSound()
    {
        
        audioSource.Play();
        Debug.Log("Shooting");


    }
}
