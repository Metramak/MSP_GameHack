using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public float timer;
    public bool ispause;
    public bool guipause;
    
    void Update()
    {
        Time.timeScale = timer;
        
        if(Input.GetKeyDown(KeyCode.Escape) && !ispause)
        {
            ispause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && ispause)
        {
            ispause = false;
        }

        if (ispause)
        {
            timer = 0;
            guipause = true;
        }
        else if (!ispause)
        {
            timer = 1f;
            guipause = false;
        }
    }

    public void OnGUI()
    {
        if (guipause)
        {
            Cursor.visible = true;
            if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2) - 150f, 150f, 45f), "Continue"))
            {
                ispause = false;
                timer = 0;
                Cursor.visible = false;
            }
            if(GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2) -50f, 150f, 45f), "Main Menu"))
            {
                ispause = false;
                timer = 0;
                SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
            }
        }
    }
}
