using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public GameObject MSP;
    public GameObject SUT;
    public GameObject MM;

    void Start()
    {
        MM.SetActive(false);
        StartCoroutine(Ch_Intro());
        Cursor.visible = false;
    }

    IEnumerator Ch_Intro()
    {
        yield return new WaitForSeconds(3.5f);
        SUT.SetActive(true);
        MSP.SetActive(false);
        yield return new WaitForSeconds(3.5f);
        SUT.SetActive(false);
        MM.SetActive(true);
        Cursor.visible = true;

    }

}
