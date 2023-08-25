using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField]
    public float TimeToLive = 5;
    public Rigidbody rb;
    public float _speed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
        _speed = 1000f;
    }


    // Update is called once per frame
    void Update()
    {
        // transform.Translate(Vector3.forward * _speed * Time.deltaTime );
        rb.velocity = new Vector3(
            rb.velocity.x,
            rb.velocity.y,
            _speed*Time.deltaTime*5
            );
    }

    

}
