using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skyhealth : MonoBehaviour
{
    public float healthlength = 232;
    public GameObject healthstring;
    public GameObject healthbar;
    public GameObject bar;
    public bool recoverhealth;
    public float weakSpell = 0.5f;
    public bool CanFade = false;
       

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SimulateHealth());
        foreach (Image im in bar.GetComponentsInChildren<Image>())
        {
            if (im.color.a > 0)
            {
                im.color = new Color(im.color.r, im.color.g, im.color.b, 1);
            }
        }
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
                //healthbar.SetActive(false);
                CanFade = true;

            }
            else
            {
                healthlength += weakSpell;
            }
        }

        if (CanFade)
        {
            Fade();
        }
    }

    public void Fade()
    {
        foreach (Image im in bar.GetComponentsInChildren<Image>())
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

    IEnumerator SimulateHealth()
    {
        yield return new WaitForSeconds(3);
        recoverhealth = true;
    }
}
