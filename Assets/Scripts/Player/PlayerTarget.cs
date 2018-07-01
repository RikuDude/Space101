using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTarget : MonoBehaviour {
    
    private Image ImgHealthBar;

    public float maxHealth = 100f;
    public float currentHealth = 100f;

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
        User.UserName = GameObject.Find("Name_Box").transform.GetChild(0).GetComponent<Text>().text;
        Debug.Log("Saved Username: " + User.UserName);
        User.Score = "" + this.gameObject.transform.GetComponent<PlayerController>().getScore();
        Debug.Log("Saved Score: " + User.Score);
        Destroy(this.gameObject);
    }


    public void updateHealthBar()
    {
        ImgHealthBar.fillAmount = currentHealth / maxHealth;
    }

    
}
