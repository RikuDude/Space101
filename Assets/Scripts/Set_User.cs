using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Set_User : MonoBehaviour {
    

   

   

    //public Text nameBox;
    public void OnEnable()
    {
       
        Text nameBox = GameObject.Find("Text_Box").GetComponent<Text>(); //as Text;
        nameBox.text = User.UserName;
        User.UserName = "";
      
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
