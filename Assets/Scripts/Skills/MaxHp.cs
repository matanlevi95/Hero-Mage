using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHp : MonoBehaviour
{
    GameManager gameManager;
    CharacterStats playerStats;
    HealthSystem healthSystem;

    private void Start()
    {
        GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        if (gameManagerObject) gameManager = gameManagerObject.GetComponent<GameManager>();
        else Destroy(gameObject);
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject)
        {
            healthSystem = playerObject.GetComponent<HealthSystem>();
            playerStats = playerObject.GetComponent<CharacterStats>();
        }
        else Destroy(gameObject);
    }

    public void ChooseSkill()
    {
        playerStats.maxHealth += 30;
        playerStats.currentHealth += 30;
        healthSystem.UpdateHealthBarIfExist();
        gameManager.HideSkillSelection();
    }
}
