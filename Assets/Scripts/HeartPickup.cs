using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    public int healAmount = 20;
    public TeammateHealth teammateHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (teammateHealth != null)
        {
            teammateHealth.Heal(healAmount);
        }

        Destroy(gameObject);
    }
}
