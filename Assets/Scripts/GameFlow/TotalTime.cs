using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalTime : MonoBehaviour {

    private Text totalTimeBoard;

	void Start () {
        totalTimeBoard = GameObject.Find("Clock").transform.GetChild(0).transform.GetChild(0).transform.GetComponent<Text>();
	}
	
	void Update () {
        totalTimeBoard.text = "" + (int)(Time.time % 6000);
        Debug.Log("Logging Time to Clock");
	}
}
