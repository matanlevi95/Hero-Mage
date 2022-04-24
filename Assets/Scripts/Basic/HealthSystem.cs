using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] Image healthBar;
    [SerializeField] TextMeshProUGUI healthText;
    CharacterStats stats;
    Animator animator;
    float delayTimer;
    [HideInInspector] public bool isDead;
    ToggleHealthBar toggleHealthBar;
    GameManager gameManager;

    void Start()
    {
        stats = GetComponent<CharacterStats>();
        animator = GetComponent<Animator>();
        toggleHealthBar = GetComponent<ToggleHealthBar>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        delayTimer -= Time.deltaTime;
    }


    public void TakeDamage(int damageAmount)
    {
        if (delayTimer > 0 || isDead) return;
        stats.currentHealth -= damageAmount;
        if (stats.currentHealth <= 0) HandleDeath();
        else HandleHurt();
        UpdateHealthBarIfExist();
    }

    public void RestoreDamage(int restoreAmount)
    {
        stats.currentHealth += restoreAmount;

        if (stats.currentHealth > stats.maxHealth)
        {
            stats.currentHealth = stats.maxHealth;
        }
        UpdateHealthBarIfExist();
    }

    public void UpdateHealthBarIfExist()
    {
        //Image;
        if (healthBar)
        {
            if (toggleHealthBar) toggleHealthBar.ShowHealthBar();
            float fillAmount = (float)stats.currentHealth / stats.maxHealth;
            healthBar.fillAmount = fillAmount;

        }
        //Text;
        if (healthText)
        {
            healthText.text = $"{stats.currentHealth}/{stats.maxHealth}";
        }
    }

    void HandleHurt()
    {
        if (animator)
        {
            animator.SetTrigger("hurt");
        }
    }

    void HandleDeath()
    {
        isDead = true;
        if (tag == "Enemy")
        {
            DropFromEnemy dropFromEnemy = GetComponent<DropFromEnemy>();
            if (dropFromEnemy) dropFromEnemy.DropLoot();
            gameManager.RemoveEnemy(gameObject);
        }
        if (animator)
        {
            animator.SetTrigger("die");
            stats.currentHealth = 0;
        }
    }

    public void AfterDeathAnimation()
    {
        
        Destroy(gameObject);
    }

    void ResetDelay()
    {
        delayTimer = stats.delayBetweenHurts;
    }
}
