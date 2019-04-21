using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkyStamina : MonoBehaviour
{
    public float staminalength = 232;
    public GameObject staminastring;
    public GameObject staminabar;
    public bool recoverstamina;
    public bool allowRun;
    public float staminaRegen = 0.3f;
    public float staminaDecrease = 30f;
    public bool CanFade = false;
    void Start()
    {
        allowRun = true;
    }

    void Update()
    {
        Debug.Log(allowRun);
        staminastring.GetComponent<RectTransform>().sizeDelta = new Vector2(staminalength, 20);

        if(recoverstamina)
        {
            if (staminalength >= 232)
            {
                recoverstamina = false;
                //staminabar.SetActive(false);
                CanFade = true;
                allowRun = true;
            }
            else
            {
                staminalength += staminaRegen;
                CanFade = false;
            }
        }

        if(staminalength < 232)
            SetAlfaInObject(staminabar, 1);

        if (staminalength <= 0)
            {
                staminalength += staminaRegen;
                allowRun = false;
            }
        

        runningTest();

        if (CanFade)
            Fade();
    }

    public void SetAlfaInObject(GameObject obj, float alfa)
    {
        foreach (Image im in obj.GetComponentsInChildren<Image>())
        {
            //if (im.color.a > 0)
            {
                im.color = new Color(im.color.r, im.color.g, im.color.b, alfa);
            }
        }
    }

    public void Fade()
    {
        foreach (Image im in staminabar.GetComponentsInChildren<Image>())
        {
            if (im.color.a > 0)
            {
                im.color = new Color(im.color.r, im.color.g, im.color.b, im.color.a - Time.deltaTime);
            }
            else
            {
                CanFade = false;
            }
        }
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
