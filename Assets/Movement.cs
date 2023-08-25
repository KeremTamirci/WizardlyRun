using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 15;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity =  new Vector3(0, 0, speed);
    }

    void OnCollisionEnter (Collision collider)
    {
        // if (collider.collider.tag is "rock" || collider.collider.tag is "enemy"){
        //     speed = 0;
        // }
    }

}
