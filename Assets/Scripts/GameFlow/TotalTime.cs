using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalTime : MonoBehaviour {

    private Text totalTimeBoard;
    //private float timePassedInMenu;

	void Start () {
        //timePassedInMenu = Time.time;
        totalTimeBoard = GameObject.Find("Clock").transform.GetChild(0).transform.GetChild(0).transform.GetComponent<Text>();
	}
	
	void Update () {
        //float currentGameTime = Time.time - timePassedInMenu;

        int minutes = (int)(Time.timeSinceLevelLoad / 60);
        int seconds = (int)(Time.timeSinceLevelLoad % 60);
        int milliseconds = (int)(Time.timeSinceLevelLoad * 100f) % 100;
        totalTimeBoard.text = "" + minutes.ToString("D2") + ":" + seconds.ToString("D2") + ":" + milliseconds.ToString("D2");
    }
}
