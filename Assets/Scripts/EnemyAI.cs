using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float attackDamage = 10f;
    public float attackCooldown = 1f;

    private NavMeshAgent agent;
    private Transform target;
    private float lastAttackTime;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // 直接找 Ally（之後可以改更乾淨）
        GameObject ally = GameObject.FindGameObjectWithTag("teammate");
        target = ally.transform;
    }

    private void Update()
    {
        if (target == null) return;

        agent.SetDestination(target.position);

        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= agent.stoppingDistance)
        {
            TryAttack();
        }
    }

    void TryAttack()
    {
        if (Time.time - lastAttackTime < attackCooldown) return;

        lastAttackTime = Time.time;

        Health health = target.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(attackDamage);
        }
    }
}
