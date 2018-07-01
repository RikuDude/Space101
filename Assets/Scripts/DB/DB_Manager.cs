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
        User.NewUser = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void makePlayer(InputField userName)
    {

        if (userName.text == string.Empty)
        {
            Text nameBox = GameObject.Find("ErrorText").GetComponent<Text>();
            nameBox.text = "Username not valid!!";

        }
        else
        {
            InsertUser(userName.text.ToString(), 0);
            SceneManager.LoadScene("Player_Game_Info");
        }

    }
    private void InsertUser(string name, int score = 0)
    {
        //UserExist(name);

        if (!UserExist(name))
        {

            using (IDbConnection dbConnection = new SqliteConnection(connectString))
            {
                dbConnection.Open();
                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    string sqlQuery = String.Format("Insert INTO space_users(name,best_score) VALUES(\"{0}\",\"{1}\")", name, score);
                    dbCmd.CommandText = sqlQuery;
                    dbCmd.ExecuteScalar();
                    dbCmd.Connection.Close();
                    User.SetUserData(name, true);
                }
            }
        }
    }

    private bool UserExist(string name)
    {
        bool userExist = false;
        try
        {
            //connectString = "URI=file:" + Application.dataPath + "/spaceDB.sqlite";
            using (IDbConnection dbConnection = new SqliteConnection(connectString))
            {
                dbConnection.Open();

                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {

                    string sqlQuery = String.Format("SELECT * FROM space_users WHERE name = \"{0}\"", name);
                    dbCmd.CommandText = sqlQuery;
                    using (IDataReader reader = dbCmd.ExecuteReader())
                    {
                        Debug.Log(reader.Read().ToString());
                        //reader.Read();
                        if ((reader.GetString(0) == name))
                        {
                            User.SetUserData(reader.GetString(0), false, reader.GetInt32(1).ToString());
                            userExist = true;
                           
                            Debug.Log("user:  " + User.UserName);

                        }
                        reader.Close();
                    }




                }

                dbConnection.Close();

                if (userExist == false)
                {
                    User.SetUserData(name, true);

                }

            }
         
            return userExist;
        }
        catch (Exception)
        {
            Text nameBox = GameObject.Find("ErrorText").GetComponent<Text>();
            nameBox.text = "DB doesn't exist!! ";

            return false;
        }

    }



}
