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
    private bool checkFire;

    void Start()
    {
        checkFire = true;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000, Layer_Mask))
        {
            newPoint = hit.point;
            Vector3 dir = (newPoint - transform.position).normalized;
            Quaternion rot = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 0.5f);
            //newPoint.y += 1.5f;
        }
        //player.transform.LookAt(newPoint);
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
        if (Input.GetMouseButtonDown(0))
        {
            if (checkFire)
            {
                checkFire = false;
                animator.SetBool("Fire", true);
                StartCoroutine(FireWait());
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            bool variable = false;
            AI newAI = other.GetComponent<AI>();
            if (newAI != null)
            {
                variable = newAI.patrule;
            }
        }
    }
    IEnumerator FireWait()
    {
        animator.SetBool("Fire", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("Fire", false);
        checkFire = true;
    }
}
