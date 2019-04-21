using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    public float number;
    void Start()
    {
        number = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = number.ToString() + "/10 медвежьих задниц";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("123");
            other.GetComponent<AI>().health -= 20f;
        }
        if (other.tag == "BEnemy")
        {
            number += 2f;
            Debug.Log("123");
            other.GetComponent<BearHealth>().health -= 20f;
        }
    }
}
