using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            Debug.Log("123");
            other.GetComponent<BearHealth>().health -= 20f;
        }
    }
}
