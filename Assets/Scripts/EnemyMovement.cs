using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    public float maxSpeed = 5;
    public float currentSpeed;
    public float stoppingDistance = 5;

    private PlayerMovement Player;
    private Animator animator;
    private NavMeshAgent agent;
    private bool startMove = false;

    private void Awake()
    {
        Player = FindObjectOfType<PlayerMovement>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private IEnumerator Start()
    {
        yield return (new WaitForSeconds(3));

    }

    private void Update()
    {
        if (!startMove)
            return;
        Move();
        
    }
    

    private void Move()
    {
        if ( Vector3.Distance(transform.position, Player.transform.position) >= stoppingDistance)
        {
            agent.SetDestination(Player.transform.position);
            animator.SetFloat("Move", currentSpeed / maxSpeed );
            currentSpeed += Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0, 5);
        }
        else
        {
            agent.SetDestination(transform.position);
            animator.SetFloat("Move", 0);
        }
    }

    private void Attack()
    {

    }
}
