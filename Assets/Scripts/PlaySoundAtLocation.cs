

using UnityEngine;

public class PlaySoundAtLocation : MonoBehaviour
{
    public Weapon weapon;
    public AudioClip SoundClip;
    //public Audio muzzleFlashSpawn;

    private void Awake()
    {
        weapon.onTriggerPull.AddListener(PlaySound);
    }

    void PlaySound()
    {
        Debug.Log("Played Sound");

    }
}
