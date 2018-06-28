using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class newGameBtnClick : MonoBehaviour
{

    public void ChangeScene(string changedtoScene)
    {
        if (changedtoScene == "Game")
        {
            Dropdown dropDownBox = GameObject.Find("Dropdown").GetComponent<Dropdown>();
            User.Difficulty = dropDownBox.value;
            Debug.Log(User.Difficulty.ToString());
            User.Difficulty = dropDownBox.value;
        }

        SceneManager.LoadScene(changedtoScene);

    }
}
