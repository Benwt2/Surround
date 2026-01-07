// Health.cs
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;

    [System.Serializable]
    public class HealthEvent : UnityEvent<int, int> { }
    public HealthEvent onHealthChanged;

    private void Awake()
    {
        currentHP = maxHP;
        onHealthChanged?.Invoke(currentHP, maxHP);
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        onHealthChanged?.Invoke(currentHP, maxHP);

        if (currentHP <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        onHealthChanged?.Invoke(currentHP, maxHP);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
