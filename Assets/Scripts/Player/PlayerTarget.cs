using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerTarget : MonoBehaviour
{

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
        ScoreUpdate(User.UserName, Int32.Parse(User.Score));
    }

    private void ScoreUpdate(string name, int score)
    {
        try
        {

            string connectString = "URI=file:" + Application.dataPath + "/spaceDB.sqlite";
            using (IDbConnection dbConnection = new SqliteConnection(connectString))
            {
                dbConnection.Open();
                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    string sqlQuery = String.Format("UPDATE space_users SET best_score = {0} WHERE name = \"{1}\"", score, name);//"Insert INTO space_users(best_score) VALUES({0}) SELECT * WHERE name=\"{1}\"", score, name);
                    dbCmd.CommandText = sqlQuery;
                    dbCmd.ExecuteScalar();
                    dbCmd.Connection.Close();
                    User.SetUserData(name, false,score.ToString());
                    SceneManager.LoadScene("BestScoreList");
                }
            }
            

        }
        catch (Exception)
        {

            throw;
        }
    }

    public void updateHealthBar()
    {
        ImgHealthBar.fillAmount = currentHealth / maxHealth;
    }


}
