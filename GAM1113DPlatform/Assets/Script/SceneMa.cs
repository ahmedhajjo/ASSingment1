using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMa : MonoBehaviour {

    // SET BACK THE SCALE TO 1 TO UNFREEZE THE GAME AND CONTROL SOME SCENES IN EDITOR
    public void buttons(string buttonName)
    {
        SceneManager.LoadScene(buttonName);

        Time.timeScale = 1;

    }

    //  THIS FUNCTION IS CALLED IN THE EDITOR TO CONTROL TE SCENE
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    // QUIT THE GAME
    public void Quit()
    {
        Application.Quit();
    }
}
