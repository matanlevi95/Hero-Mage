using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerExperience : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] Image xpBar;
    [SerializeField] Text levelText;
    [SerializeField] Text xpText;

    CharacterStats playerStats;
    GameManager gameManager;

    [Header("Multipliers")]
    [Range(1f, 300f)]
    [SerializeField] float additionMultiplier = 300f;
    [Range(2f, 4f)]
    [SerializeField] float powerMultiplier = 2f;
    [Range(7f, 14f)]
    [SerializeField] float divisionMultiplier = 7f;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<CharacterStats>();
        GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
        CalculateRequiredXp();
        xpBar.fillAmount = playerStats.currentXp / playerStats.requiredXp;
        levelText.text = "" + playerStats.level;
        UpdateXpUI();

    }
    public void UpdateXpUI()
    {
        xpBar.fillAmount = (float)playerStats.currentXp / playerStats.requiredXp;
        xpText.text = Mathf.Round(playerStats.currentXp) + "/" + Mathf.Round(playerStats.requiredXp);
    }

    public void GainExperienceFlatRate(int xpGained)
    {
        playerStats.currentXp += xpGained;
        if (playerStats.currentXp >= playerStats.requiredXp) LevelUp();
        UpdateXpUI();
    }

    public void LevelUp()
    {
        playerStats.level++;
        xpBar.fillAmount = 0;
        playerStats.currentXp = Mathf.RoundToInt(playerStats.currentXp - playerStats.requiredXp);
        levelText.text = "" + playerStats.level;
        CalculateRequiredXp();
        gameManager.ShowSkillSelection();
    }

    private void CalculateRequiredXp()
    {
        int solveForRequiredXp = 0;
        for (int levelCycle = 1; levelCycle <= playerStats.level; levelCycle++)
        {
            solveForRequiredXp += (int)Mathf.Floor(levelCycle + additionMultiplier * Mathf.Pow(powerMultiplier, levelCycle / divisionMultiplier));
        }
        playerStats.requiredXp = solveForRequiredXp / 4;
    }

}
