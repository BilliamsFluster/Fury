using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    public Weapon weapon;
    public ParticleSystem muzzleFlashEffect;

    private void Awake()
    {
        weapon.onTriggerPull.AddListener(ShowMuzzleFlash);
    }

    void ShowMuzzleFlash()
    {
        muzzleFlashEffect.Play();
    }
}
