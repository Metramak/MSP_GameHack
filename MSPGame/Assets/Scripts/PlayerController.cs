using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public LayerMask Layer_Mask;
    private Vector3 newPoint;
    public GameObject player;
    public float speed = 7f;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000, Layer_Mask))
        {
            newPoint = hit.point;
            newPoint.y += 1.5f;
        }
        player.transform.LookAt(newPoint);
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.position += Vector3.forward * Time.deltaTime * speed;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed += 15f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed -= 15f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.position += -Vector3.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position += Vector3.right * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position += Vector3.left * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Run", true);
        }
        else if (Input.GetKeyUp(KeyCode.W) | Input.GetKeyUp(KeyCode.S) | Input.GetKeyUp(KeyCode.D) | Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Run", false);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            
        }
    }
}
