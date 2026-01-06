using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject weaponPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            teamWeaponSlot slot = Object.FindFirstObjectByType<teamWeaponSlot>();
            if (slot != null)
            {
                slot.EquipWeapon(weaponPrefab);
            }

            Destroy(gameObject);
        }
    }
}


