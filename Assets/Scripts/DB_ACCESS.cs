using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class player
{
    int _name;
    string _password;
    string _highScore;
    int _kredits;

    public player(int name, string password, string highscore, int kredit)
    {
        this._name = name;
        this._password = password;
        this._highScore = highscore;
        this._kredits = kredit;
    }

    public int Name { get { return _name; } }
    public string Password { get { return _password; } }
    public string HighScore { get { return _highScore; } }
    public int Kredits { get { return _kredits; } }
}


public class DB_ACCESS : MonoBehaviour {


    //player[] Player = new player[0]{ "George", "3185", "200","100"};
    //employees[0] = new Employee(1, "David", "Smith", 10000);
    //employees[1] = new Employee(3, "Mark", "Drinkwater", 30000);
    //employees[2] = new Employee(4, "Norah", "Miller", 20000);
    //employees[3] = new Employee(12, "Cecil", "Walker", 120000);


    //using (XmlWriter writer = XmlWriter.Create("employees.xml"))
    //{
    //    writer.WriteStartDocument();
    //    writer.WriteStartElement("Employees");

    //    foreach (Employee employee in employees)
    //    {
    //        writer.WriteStartElement("Employee");

    //        writer.WriteElementString("ID", employee.Id.ToString());
    //        writer.WriteElementString("FirstName", employee.FirstName);
    //        writer.WriteElementString("LastName", employee.LastName);
    //        writer.WriteElementString("Salary", employee.Salary.ToString());

    //        writer.WriteEndElement();
    //    }

    //    writer.WriteEndElement();
    //    writer.WriteEndDocument();
    //}







    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
