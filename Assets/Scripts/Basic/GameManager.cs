using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> enemies;
    Animator gateAnimator;
    [SerializeField] GameObject skillsSelection;
    public List<Transform> subSpells;
    // Start is called before the first frame update
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
        if (enemies.Count <= 0 && gateAnimator) gateAnimator.SetTrigger("open");
    }

    public void AddEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
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
