using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoost : MonoBehaviour
{
    GameManager gameManager;
    CharacterStats playerStats;

    private void Start()
    {
        GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        if (gameManagerObject) gameManager = gameManagerObject.GetComponent<GameManager>();
        else Destroy(gameObject);
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject) playerStats = playerObject.GetComponent<CharacterStats>();
        else Destroy(gameObject);
    }

    public void ChooseSkill()
    {
        playerStats.minDamage += 2;
        playerStats.maxDamage += 5;
        gameManager.HideSkillSelection();
    }

}
