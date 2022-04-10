using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] int numberOfEnemiesInLevel;
   public List<GameObject> enemies;
    Animator gateAnimator;
    // Start is called before the first frame update
    void Start()
    {
        numberOfEnemiesInLevel = GameObject.FindGameObjectsWithTag("Enemy").Length;
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
        if (enemies.Count <= 0 && gateAnimator) gateAnimator.SetTrigger("open");
    }

    public void AddEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
    }
}
