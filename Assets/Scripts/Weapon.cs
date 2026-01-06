using UnityEngine;

public class WeaponOrbit : MonoBehaviour
{
    public Transform centerTarget;
    public float radius = 1.5f;
    public float rotationSpeed = 180f;
    public float damage = 15f;

    [Header("使用時間")]
    public float duration = 10f;

    private float angle;
    private float timer;

    private void Start()
    {
        timer = duration;
    }

    private void Update()
    {
        if (centerTarget == null) return;

        // 倒數
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Destroy(gameObject);
            return;
        }

        angle += rotationSpeed * Time.deltaTime;

        float rad = angle * Mathf.Deg2Rad;
        Vector3 offset = new Vector3(
            Mathf.Cos(rad) * radius,
            0,
            Mathf.Sin(rad) * radius
        );

        transform.position = centerTarget.position + offset;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Health health = other.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }
}

