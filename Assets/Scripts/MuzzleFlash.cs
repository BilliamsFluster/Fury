using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    [Tooltip("weapon to bind events to.")]
    public Weapon weapon;
    [Tooltip("spawn a muzzle flash.")]
    public GameObject muzzleFlashEffect;
    [Tooltip("location to spawn muzzleflash.")]
    public GameObject muzzleFlashSpawn;

    private void Awake()
    {
        weapon.onTriggerPull.AddListener(ShowMuzzleFlash);
    }

    void ShowMuzzleFlash()
    {
        // Instantiate the muzzle flash effect at the weapon's position and rotation
        GameObject instantiatedMuzzleFlash = Instantiate(muzzleFlashEffect, muzzleFlashSpawn.transform.position, muzzleFlashSpawn.transform.rotation);

        // Destroy the instantiated muzzle flash after a short delay (e.g., 0.5 seconds)
        Destroy(instantiatedMuzzleFlash, 0.5f);
    }
}
