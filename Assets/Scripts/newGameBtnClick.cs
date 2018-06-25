using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newGameBtnClick : MonoBehaviour {

public void ChangeScene(string changedtoScene)
    {
        SceneManager.LoadScene(changedtoScene);
        
    }
}
