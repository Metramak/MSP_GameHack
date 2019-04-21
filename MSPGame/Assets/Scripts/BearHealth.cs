using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearHealth : MonoBehaviour
{
    public float health;

    void Start()
    {
        health = 100f;
    }

    
    void Update()
    {
        LiveObj();
    }
    void LiveObj()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
