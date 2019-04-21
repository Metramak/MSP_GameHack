using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ROADTOSKYRIM : MonoBehaviour
{
    public GameObject player;
    public GameObject whs;
    public GameObject fire;
    public GameObject hand;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (hand.GetComponent<DamagePlayer>().number == 10)
            {
                StartCoroutine(GoToSkyrim());
            }
        }
    }

    IEnumerator GoToSkyrim()
    {
        
        fire.SetActive(true);
        yield return new WaitForSeconds(3);
        Cursor.visible = false;

        SceneManager.LoadScene("CutSceneSkyrim", LoadSceneMode.Single);

    }
}
