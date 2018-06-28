using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTarget : MonoBehaviour {
    
    private Image ImgHealthBar;

    private float maxHealth = 50f;
    private float currentHealth = 50f;

    private void Start()
    {
        ImgHealthBar = GameObject.Find("Player1HUD").transform.GetChild(0).transform.GetChild(1).GetComponent<Image>();
    }
    
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0f)
        {
            Die();
        }
        updateHealthBar();
    }

    public void TakeHealing(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        updateHealthBar();

    }

    private void Die()
    {
        Destroy(this.gameObject);
    }


    public void updateHealthBar()
    {
        ImgHealthBar.fillAmount = currentHealth / maxHealth;
    }

    
}
