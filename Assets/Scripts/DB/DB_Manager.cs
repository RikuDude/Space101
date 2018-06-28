using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DB_Manager : MonoBehaviour
{

    //ConnectString
    private string connectString;
    
  
    // Use this for initialization
    void Start()
    {

        connectString = "URI=file:" + Application.dataPath + "/spaceDB.sqlite";

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void makePlayer(InputField userName)
    {

        if (userName.text ==string.Empty)
        {
            Text nameBox = GameObject.Find("ErrorText").GetComponent<Text>();
            nameBox.text = "Username not valid!!";
             
        }
        else
        {
            InsertUser(userName.text, 0, 0);
            //newGameBtnClick.ChangeScene("Player_Game_Info");
            SceneManager.LoadScene("Player_Game_Info");
        }
       
    }
    private void InsertUser(string name, int score = 0, int totalPoints = 0)
    {
        if (!UserExist(name))
        {

            using (IDbConnection dbConnection = new SqliteConnection(connectString))
            {
                dbConnection.Open();
                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    string sqlQuery = String.Format("Insert INTO space_users(name,best_score,total_points) VALUES(\"{0}\",\"{1}\",\"{2}\")", name, score, totalPoints);
                    dbCmd.CommandText = sqlQuery;
                    dbCmd.ExecuteScalar();
                    dbCmd.Connection.Close();
                }
            }
        }
    }

    private bool UserExist(string name)
    {
        try
        {
            using (IDbConnection dbConnection = new SqliteConnection(connectString))
            {
                dbConnection.Open();
                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    string sqlQuery = String.Format("SELECT * FROM space_users WHERE name = \"{0}\"", name);
                    dbCmd.CommandText = sqlQuery;
                    using (IDataReader reader = dbCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetString(1) != "")
                            {
                                User.SetUserData(reader.GetString(0), false, reader.GetString(1), reader.GetString(2));
                                return true;
                            }
                        }

                        reader.Close();
                        dbConnection.Close();

                    }
                }

                User.SetUserData(name, true);
                return false;
            }
        }
        catch (Exception e)
        {
            Text nameBox = GameObject.Find("ErrorText").GetComponent<Text>();
            nameBox.text = "DB doesnt exist!!";
            return false;
        }
       
    }


    //public void FillListView(Text Listtxt)
    //{
    //    GetScores();
    //    foreach (var item in bestScores)
    //    {
    //        Listtxt.text += item.ToString() + "\n";
    //    }
    //}
    //public List<string>  GetScores()
    //{       string connectString = "URI=file:" + Application.dataPath + "/spaceDB.sqlite";

    //         bestScores.Clear();
        
    //    using (IDbConnection dbConnection = new SqliteConnection(connectString))
    //    {
    //        dbConnection.Open();

    //        using (IDbCommand dbCmd = dbConnection.CreateCommand())
    //        {
    //            string sqlQuery = "SELECT * FROM space_users ORDER BY best_score DESC";
    //            dbCmd.CommandText = sqlQuery;
    //            using (IDataReader reader = dbCmd.ExecuteReader())
    //            {
    //                while (reader.Read())
    //                {
                       
    //                    bestScores.Add(reader.GetString(0) + "  " + reader.GetString(1));
    //                    //Debug.Log(reader.GetString(0) + " " + reader.GetString(1));
    //                }
                    
    //                dbConnection.Close();
    //                reader.Close();
    //                return bestScores;
    //            }
    //        }
    //    }
    //}
}
