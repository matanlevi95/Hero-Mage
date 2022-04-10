using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Header("health")]
    public int maxHealth = 100;
    public int currentHealth;
    public float delayBetweenHurts = 1.5f;

    [Header("Attack")]
    public int minDamage = 10;
    public int maxDamage = 15;
    public bool needToBeAtDistanceFromTargetForAttacking = false;
    public float minDistanceFromTargetForAttacking;
    public float delayBetweenAttacks = 1.5f;

    [Header("Movement")]
    public float speed = 10f;
    public bool needToBeAtDistanceFromTargetForMoving = false;
    public float minDistanceFromTargetForMoving = 10;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

}
