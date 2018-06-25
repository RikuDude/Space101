using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUserInfo : MonoBehaviour {


    private void OnEnable()
    {
        Text nameBox = GameObject.Find("Text_PlayerInfo").GetComponent<Text>(); 
        nameBox.text = User.UserName;
        
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
