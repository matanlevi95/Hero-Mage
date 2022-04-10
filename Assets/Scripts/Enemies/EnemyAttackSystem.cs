using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackSystem : MonoBehaviour
{

    Animator animator; 
    CharacterStats stats;
    Transform target;
    float delayTimer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        stats = GetComponent<CharacterStats>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (!target) return;
        delayTimer -= Time.deltaTime;
        if (delayTimer < 0)
        {
            if (CheckIfTargetInDistance()) StartAttack();
        }
    }

    bool CheckIfTargetInDistance()
    {
        if (stats.needToBeAtDistanceFromTargetForAttacking)
        {
            float distanceFromTarget = Vector3.Distance(transform.position, target.position);
            if (distanceFromTarget <= stats.minDistanceFromTargetForAttacking)
            {
                return true;
            }
            return false;
        }
        return true;
    }

    void StartAttack()
    {
        HealthSystem targetHealth = target.GetComponent<HealthSystem>();
        if (!targetHealth.isDead)
        {
            animator.SetTrigger("attack");
            ResetTimer();
        }
    }

    void AttackIfStillInRange()
    {
        if (CheckIfTargetInDistance())
        {
            HealthSystem targetHealth = target.GetComponent<HealthSystem>();

            int randomDamageAmount = Random.Range(stats.minDamage, stats.maxDamage);
            targetHealth.TakeDamage(randomDamageAmount);

        }
    }

    void ResetTimer()
    {
        delayTimer = stats.delayBetweenAttacks;
    }
}
