using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;

public class SetTopScores : MonoBehaviour
{
    Text nameBox;
    // Use this for initialization
    void Start()
    {
        SetScoreList();
    }

    private void SetScoreList()
    {


        string connectString = "URI=file:" + Application.dataPath + "/spaceDB.sqlite";

        string objectText = "playerNametxt";
        string tempTextObjekt = "";

        using (IDbConnection dbConnection = new SqliteConnection(connectString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM space_users ORDER BY best_score DESC LIMIT 2";
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    int i = 1;
                    while ((reader.Read()) && (i < 6))
                    {
                        tempTextObjekt = Convert.ToString(objectText + i.ToString());

                        nameBox = GameObject.Find(tempTextObjekt).GetComponent<Text>();
                        nameBox.text = Convert.ToString(reader.GetString(0) + "  " + reader.GetString(1));
                        tempTextObjekt = "";
                        Debug.Log(tempTextObjekt);
                        i++;
                        //Debug.Log(reader.GetString(0) + " " + reader.GetString(1));
                    }

                    dbConnection.Close();
                    reader.Close();

                }
            }
        }




    }

    // Update is called once per frame
    void Update()
    {

    }
}
