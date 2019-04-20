using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    public void playPressed()
    {
        SceneManager.LoadScene("");

    }

    public void exitPressed()
    {
        Application.Quit();
    }
}
