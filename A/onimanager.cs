using UnityEngine;
using UnityEngine.AI;

public class Onimanager : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent agent;

    [Header("Chase Settings")]
    public float chaseSpeed = 3f;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.speed = chaseSpeed;
    }

    private void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.transform.position);
            agent.speed = chaseSpeed;
        }
    }
}
