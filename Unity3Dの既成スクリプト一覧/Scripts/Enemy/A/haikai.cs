using UnityEngine;
using UnityEngine.AI;

public class haikai : MonoBehaviour
{
    private NavMeshAgent agent;

    [Header("Haikai Settings")]
    public float wanderSpeed = 1f;
    public float wanderRadius = 10f;
    public float wanderDelay = 3f;

    private float timer;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = wanderSpeed;
        timer = wanderDelay;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderDelay)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius);
            agent.SetDestination(newPos);
            timer = 0f;
        }

        agent.speed = wanderSpeed;
    }

    private Vector3 RandomNavSphere(Vector3 origin, float dist)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;

        NavMeshHit navHit;
        if (NavMesh.SamplePosition(randDirection, out navHit, dist, NavMesh.AllAreas))
        {
            return navHit.position;
        }

        return origin;
    }
}
