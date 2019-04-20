using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{

    public Transform View;
    public float x;
    public float y;
    public float z;

    void Start()
    {
        View = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        transform.position = View.position + new Vector3(x, y, z);
    }
}