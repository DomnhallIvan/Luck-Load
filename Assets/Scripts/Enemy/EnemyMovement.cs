using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    [SerializeField] private PlayerController playerRef;
    public float agentStoppingDistance = 20f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
       playerRef= FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!agent.pathPending&&agent.remainingDistance <=agentStoppingDistance)
        agent.SetDestination(playerRef.gameObject.transform.position);
    }
}
