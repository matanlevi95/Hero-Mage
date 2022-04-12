using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleHealthBar : MonoBehaviour
{
    [SerializeField] GameObject healthBar;
    [SerializeField] float showTime;
    float timer;

    private void Start()
    {
        HideHealthBar();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            HideHealthBar();
        }
    }

    private void ResetTimer()
    {
        timer = showTime;
    }

    public void ShowHealthBar()
    {
        healthBar.SetActive(true);
        ResetTimer();
    }

    public void HideHealthBar()
    {

        healthBar.SetActive(false);
    }
}
