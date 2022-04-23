using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedBoost : MonoBehaviour
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
        playerStats.delayBetweenAttacks -= 0.2f;
        gameManager.HideSkillSelection();
    }
}
