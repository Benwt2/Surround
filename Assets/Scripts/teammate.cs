using UnityEngine;
using UnityEngine.AI;

public class AllyMovement : MonoBehaviour
{
    private NavMeshAgent agent;

    [Header("移動範圍")]
    public float moveRadius = 8f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MoveToRandomPoint();
    }

    private void Update()
    {
        // 如果快到目的地，就找新的點
        if (!agent.pathPending && agent.remainingDistance <= 0.5f)
        {
            MoveToRandomPoint();
        }
    }

    void MoveToRandomPoint()
    {
        Vector3 randomDirection = Random.insideUnitSphere * moveRadius;
        randomDirection += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, moveRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }
}