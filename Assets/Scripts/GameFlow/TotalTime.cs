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
        int minutes = (int)(Time.time / 60);
        int seconds = (int)(Time.time % 60);
        int milliseconds = (int)(Time.timeSinceLevelLoad * 100f) % 100;
        totalTimeBoard.text = "" + minutes.ToString("D2") + ":" + seconds.ToString("D2") + ":" + milliseconds.ToString("D2");
    }
}
