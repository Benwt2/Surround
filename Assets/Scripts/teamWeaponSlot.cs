using UnityEngine;

public class teamWeaponSlot : MonoBehaviour
{
    public Transform weaponPivot;
    private GameObject currentWeapon;

    public void EquipWeapon(GameObject weaponPrefab)
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
        }

        // 先生成成為子物件
        currentWeapon = Instantiate(weaponPrefab, weaponPivot);

        // 關鍵：明確設定「本地座標」
        currentWeapon.transform.localPosition = new Vector3(1.5f, 0f, 0f);
        currentWeapon.transform.localRotation = Quaternion.identity;
    }
}

