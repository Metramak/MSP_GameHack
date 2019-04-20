using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skyhealth : MonoBehaviour
{
    public float healthlength = 232;
    public GameObject healthstring;
    public GameObject healthbar;
    public bool recoverhealth;
    public float weakSpell = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SimulateHealth());
    }

    // Update is called once per frame
    void Update()
    {
        healthstring.GetComponent<RectTransform>().sizeDelta = new Vector2(healthlength, 20);

        if(recoverhealth)
        {
            if(healthlength >= 232)
            {
                recoverhealth = false;
                healthbar.SetActive(false);

            }
            else
            {
                healthlength += weakSpell;
            }
        }
    }

    IEnumerator SimulateHealth()
    {
        yield return new WaitForSeconds(5);
        healthlength -= 30;
        yield return new WaitForSeconds(2);
        healthlength -= 20;
        yield return new WaitForSeconds(3);
        healthlength -= 40;
        yield return new WaitForSeconds(3);
        recoverhealth = true;
        yield return new WaitForSeconds(10);    
        healthbar.SetActive(true);
        healthlength -= 232;
    }
}
