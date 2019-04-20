using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyStamina : MonoBehaviour
{
    public float staminalength = 232;
    public GameObject staminastring;
    public GameObject staminabar;
    public bool recoverstamina;
    public bool allowRun = true;
    public float staminaRegen = 0.3f;
    public float staminaDecrease = 30f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        staminastring.GetComponent<RectTransform>().sizeDelta = new Vector2(staminalength, 20);

        if(recoverstamina)
        {
            if (staminalength >= 232)
            {
                recoverstamina = false;
                staminabar.SetActive(false);
                allowRun = true;
            }
            else
            {
                staminalength += staminaRegen;
            }
        }
        
        if (staminalength <= 0)
            {
                staminalength += staminaRegen;
                allowRun = false;
            }
        

        runningTest();
    }

    void runningTest()
    {
        if(Input.GetKey(KeyCode.LeftShift) && allowRun)
        {
            staminalength -= staminaDecrease * Time.deltaTime;
            staminabar.SetActive(true);
            recoverstamina = false;
        }
        else
        {
            if(Input.GetKeyUp(KeyCode.LeftShift))
            {
                StartCoroutine(SimulateStamina());
            }
        }
    }

    IEnumerator SimulateStamina ()
    {
        yield return new WaitForSeconds(3);
        recoverstamina = true;
    }
}
