using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Animator animator;
    CharacterStats stats;
    Transform target;
    NavMeshAgent navMeshAgent;
    GameManager gameManager;
    void Start()
    {
        animator = GetComponent<Animator>();
        stats = GetComponent<CharacterStats>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (!target) return;
        if (CheckIfNeedToMove()) Move();
        else
        {
            navMeshAgent.destination = transform.position;
            animator.SetBool("walking", false);
        }
    }

    void Move()
    {
        navMeshAgent.destination = target.position;
       // transform.Translate(Vector3.forward * stats.speed * Time.deltaTime);
       // transform.LookAt(target);
        animator.SetBool("walking", true);
    }

    bool CheckIfNeedToMove()
    {
        if (stats.needToBeAtDistanceFromTargetForMoving)
        {
            float distanceFromTarget = Vector3.Distance(transform.position, target.position);
            if (distanceFromTarget <= stats.minDistanceFromTargetForMoving && distanceFromTarget > stats.minDistanceFromTargetForAttacking)
            {
                return true;
            }
            return false;
        }
        return true;
    }

    private void OnDestroy()
    {
        gameManager.RemoveEnemy(gameObject);
    }


}
