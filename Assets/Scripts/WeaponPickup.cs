using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [Header("要給隊友的武器")]
    public GameObject weaponPrefab;

    [Header("隊友的武器插槽")]
    public teamWeaponSlot targetSlot;

    private void OnTriggerEnter(Collider other)
    {
        // 只允許玩家撿
        if (!other.CompareTag("Player"))
            return;

        // 安全檢查
        if (weaponPrefab == null)
        {
            Debug.LogWarning("WeaponPickup：weaponPrefab 尚未設定");
            return;
        }

        if (targetSlot == null)
        {
            Debug.LogWarning("WeaponPickup：targetSlot 尚未設定");
            return;
        }

        // 給武器
        targetSlot.EquipWeapon(weaponPrefab);

        // 移除地上的 Pickup
        Destroy(gameObject);
    }
}

