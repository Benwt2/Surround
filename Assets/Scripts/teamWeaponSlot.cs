using UnityEngine;

public class teamWeaponSlot : MonoBehaviour
{
    public Transform weaponPivot;

    private GameObject currentWeapon;

    public void EquipWeapon(GameObject weaponPrefab)
    {
        // 如果有舊武器，先移除
        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
        }

        currentWeapon = Instantiate(
            weaponPrefab,
            weaponPivot.position,
            Quaternion.identity,
            weaponPivot
        );
    }
}
