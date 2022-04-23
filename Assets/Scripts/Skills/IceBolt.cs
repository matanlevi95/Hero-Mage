using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceBolt : MonoBehaviour
{
    GameManager gameManager;
    CharacterStats playerStats;
    [SerializeField] Transform iceBolt;

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
        playerStats.spellsAbillities.Add(iceBolt);
        gameManager.HideSkillSelection();
    }
}
