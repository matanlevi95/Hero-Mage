using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct CoinsPrefabs
{
    public int min;
    public int max;
    public Transform coinPrefab;
}
public class GameManager : MonoBehaviour
{
    Animator gateAnimator;

    [Header("Enemies")]
    public List<GameObject> enemies;
    [Header("Skills")]
    [SerializeField] GameObject skillsSelection;
    public List<Transform> subSpells;
    // Start is called before the first frame update
    [Header("Coin")]
    public CoinsPrefabs[] coinsTypes;


    void Start()
    {
        GameObject gate = GameObject.FindGameObjectWithTag("Gate");
        gateAnimator = gate.GetComponent<Animator>();
        GameObject[] enemiesArray = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemiesArray)
        {
            enemies.Add(enemy);
        }
    }
    public void RemoveEnemy(GameObject enemy)
    {
        if (enemies.Contains(enemy)) enemies.Remove(enemy);
        if (enemies.Count <= 0 && gateAnimator) HandleEndStage();
    }

    public void AddEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
    }

    void HandleEndStage()
    {
        OpenGate();
        MoveAllCoinsToPlayer();
    }

    void OpenGate()
    {
        gateAnimator.SetTrigger("open");
    }

    void MoveAllCoinsToPlayer()
    {
        Coin[] coins = FindObjectsOfType<Coin>();
        foreach (var coin in coins)
        {
            coin.move = true;
        }
    }

    public void ShowSkillSelection()
    {
        skillsSelection.SetActive(true);
    }

    public void HideSkillSelection()
    {
        skillsSelection.SetActive(false);
    }
}
