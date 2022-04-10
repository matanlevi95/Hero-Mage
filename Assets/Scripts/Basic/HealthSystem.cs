using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] Image healthBar;
    CharacterStats stats;
    Animator animator;
    float delayTimer;
    [HideInInspector] public bool isDead;

    void Start()
    {
        stats = GetComponent<CharacterStats>();
        animator = GetComponent<Animator>();
        ResetDelay();
    }

    private void Update()
    {
        delayTimer -= Time.deltaTime;
    }


    public void TakeDamage(int damageAmount)
    {
        if (delayTimer > 0 || isDead) return;
        stats.currentHealth -= damageAmount;
        if (stats.currentHealth <= 0)
        {
            isDead = true;
            HandleDeath();
        }
        else
        {
            HandleHurt();
        }
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

    void UpdateHealthBarIfExist()
    {
        if (healthBar)
        {
            float fillAmount = (float)stats.currentHealth / stats.maxHealth;
            healthBar.fillAmount = fillAmount;
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
        if (animator)
        {
            animator.SetTrigger("die");
            stats.currentHealth = 0;
            Destroy(gameObject, 2);
        }
    }

    void ResetDelay()
    {
        delayTimer = stats.delayBetweenHurts;
    }
}
