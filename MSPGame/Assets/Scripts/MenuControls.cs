using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    public void playPressed()
    {
        SceneManager.LoadScene("Assets/Scenes/LevelOne.unity", LoadSceneMode.Single);

    }

    public void exitPressed()
    {
        Application.Quit();
    }
}
