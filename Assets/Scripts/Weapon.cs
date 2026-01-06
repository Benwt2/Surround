using UnityEngine;

public class WeaponOrbit : MonoBehaviour
{
    public Transform centerTarget;
    public float radius = 1.5f;
    public float rotationSpeed = 180f; // «× / ¬í
    public float damage = 15f;

    private float angle;

    private void Update()
    {
        if (centerTarget == null) return;

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

