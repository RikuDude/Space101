using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTarget : MonoBehaviour {
    
    public Image ImgHealthBar;

    private float maxHealth = 50f;
    private float currentHealth = 50f;


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
