using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{
    public Animator anim;
    public bool isDead;
    public bool revived;
    public float speed;
    public Manager mng;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isDead = false;
        revived = false;
        speed = 1000f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag is "enemy" ||collision.collider.tag is "obstacle")
        {
            isDead = true;
            Debug.Log("öldüm");
            anim.SetBool("dead", true);
            anim.SetBool("paid", false);
            FindObjectOfType<Manager>().DisablePlayer();
            rb.velocity = new Vector3(0, 0, 0);
            FindObjectOfType<Manager>().DeathFunction();
        }
    }

    public void Revive()
    {
        isDead = false;
        revived = true;
        anim.SetBool("paid", true);
        anim.SetBool("dead", false);
        Invoke("InvokeToStart", 1);
        
    }

    public void InvokeToStart()
    {
        FindObjectOfType<Manager>().StartFunction();
    }
}