using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class NewBehaviourScript : MonoBehaviour {

    public Button exploreSpaceButton;

    public void OnClick()
    {
        SceneManager.LoadScene("Game");
    }

	// Use this for initialization
	void Start () {
        Button btn = exploreSpaceButton.GetComponent<Button>();
        //Calls the TaskOnClick method when you click the Button
        btn.onClick.AddListener(TaskOnClick);

        //exploreSpaceButton.onClick.AddListener(delegate { TaskWithParameters("Hello"); });
    }

    void TaskOnClick()
    {
        //Application.LoadLevel("Game");
        SceneManager.LoadScene("Game");
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
