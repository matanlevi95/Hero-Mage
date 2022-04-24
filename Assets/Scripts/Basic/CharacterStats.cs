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
        if (tag == "Player")
        {
            level = PlayerStats.level;
            requiredXp = PlayerStats.requiredXp;
            currentXp = PlayerStats.currentXp;
            maxHealth = PlayerStats.maxHealth;
            currentHealth = PlayerStats.currentHealth;
            delayBetweenHurts = PlayerStats.delayBetweenHurts;
            minDamage = PlayerStats.minDamage;
            maxDamage = PlayerStats.maxDamage;
            delayBetweenAttacks = PlayerStats.delayBetweenAttacks;
            speed = PlayerStats.speed;
            spellsAbillities = PlayerStats.spellsAbillities;
        }
        else
        {
            currentHealth = maxHealth;
        }

    }

    private void OnDestroy()
    {
        if (tag == "Player")
        {
            PlayerStats.level = level;
            PlayerStats.requiredXp = requiredXp;
            PlayerStats.currentXp = currentXp;
            PlayerStats.maxHealth = maxHealth;
            PlayerStats.currentHealth = currentHealth;
            PlayerStats.delayBetweenHurts = delayBetweenHurts;
            PlayerStats.minDamage = minDamage;
            PlayerStats.maxDamage = maxDamage;
            PlayerStats.delayBetweenAttacks = delayBetweenAttacks;
            PlayerStats.speed = speed;
        }
    }
}

public static class PlayerStats
{
    public static int level = 1;
    public static int requiredXp = 0;
    public static int currentXp = 0;
    public static int maxHealth = 100;
    public static int currentHealth;
    public static int minDamage = 10;
    public static int maxDamage = 15;
    public static float delayBetweenAttacks = 1.5f;
    public static float delayBetweenHurts = 1.5f;
    public static float speed = 10f;
    public static List<Transform> spellsAbillities;
}
