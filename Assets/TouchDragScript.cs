using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDragScript : MonoBehaviour
{
    private Touch touch;
    public float speedMod;
    public Rigidbody wizard;
    public Animator anim;
    public bool started = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        speedMod = 0.2f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            anim.SetBool("gameStarted", true);
        }
        if (transform.position.x > 3) {
            transform.position = new Vector3(
            3,
            transform.position.y,
            transform.position.z
        );
        }

        if (transform.position.x < -3) {
            transform.position = new Vector3(
                -3,
                transform.position.y,
                transform.position.z
            );
        }

        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
        
            if(touch.phase == TouchPhase.Moved)
            {
                wizard.velocity = new Vector3(
                    transform.position.x + touch.deltaPosition.x * speedMod,
                    wizard.velocity.y,
                    wizard.velocity.z
                );

            }
        }
        
    }
}
