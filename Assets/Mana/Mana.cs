using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 1f;
    //adjust this to change how high it goes
    float height = 0.2f;
    public bool add;
    public bool multiply;
    public bool subtract;
    public int x = 10;
    public float start_x;
    public float start_z;
    void Start()
    {
        start_x = transform.position.x;
        start_z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //get the objects current position and put it in a variable so we can access it later with less code
        //Vector3 pos = transform.position;
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed) + 4.0f;
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(start_x, newY * height, start_z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetType() == typeof(CapsuleCollider))
        {
            Mana_Collection player = other.GetComponent<Mana_Collection>();
            
            if (player != null)
            {
                player.AddMana(add, multiply, subtract, x);   
            }
            Destroy(this.gameObject);
        }


    }

}

