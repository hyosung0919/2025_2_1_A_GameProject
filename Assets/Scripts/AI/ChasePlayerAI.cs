using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayerAI : MonoBehaviour
{
    public Transform player;                                        //유저 위치
    public float chaseRange = 50.0f;
    public float attackRange = 2.0f;

    private NavMeshAgent agent;                                     //길찾기 알고리즘을 지원 해주는 AI Agent
    private float distanceToPlayer;                                 //플레이어와의 거리

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseRange)
        {
            ChasePlayer();
        }
        else
        {
            StopChasing();
        }

        if (distanceToPlayer <= attackRange)
        {
            Attack();
        }
    }

    void ChasePlayer()
    {
        agent.isStopped = false;
        agent.SetDestination(player.position);                      //플레이어 위치로 목적지를 설정한다.
    }

    void StopChasing()
    {
        agent.isStopped = true;
    }

    void Attack()
    {
        agent.isStopped = true;
        transform.LookAt(player);
        Debug.Log("Attacking player!");
    }

    private void OnDrawGizmosSelected()                             //Gizmos로 범위 표시
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
