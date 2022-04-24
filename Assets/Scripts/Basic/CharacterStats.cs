using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Header("Level")]
    public int level = 1;
    public int requiredXp = 0;
    public int currentXp = 0;


    [Header("health")]
    public int maxHealth = 100;
    [HideInInspector] public int currentHealth;
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

    [Header("Skills")]
    [HideInInspector] public List<Transform> spellsAbillities;

    private void Awake()
    {
        currentHealth = maxHealth;
        spellsAbillities = new List<Transform>();
    }

}
