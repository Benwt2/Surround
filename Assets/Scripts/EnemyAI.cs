// EnemyAI.cs
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public int attackDamage = 5;
    public float attackInterval = 1.5f;

    private float timer;
    private NavMeshAgent agent;
    private Transform target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Teammate").transform;
    }

    void Update()
    {
        if (target == null) return;

        agent.SetDestination(target.position);
        timer += Time.deltaTime;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform == target && timer >= attackInterval)
        {
            Health health = target.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(attackDamage);
            }
            timer = 0f;
        }
    }
}

