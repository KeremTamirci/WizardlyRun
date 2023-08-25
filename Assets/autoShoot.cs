using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoShoot : MonoBehaviour
{
    public bool mustShoot;
    public bool shootingStarted = true;
    public Fire Fire;
    public bool touching;
    float elapsed = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        mustShoot = false;
        touching = false;
    }
    public void FireUp()
    {
        FindObjectOfType<Fire>().Shoot();
    }
    // Update is called once per frame
    void Update()
    {


        elapsed += Time.deltaTime;
        if (elapsed >= 0.3f && mustShoot && touching)
        {
            elapsed = elapsed % 0.3f;
            FireUp();
        }
        touching = false;
        mustShoot = false;

    }

    public void OnTriggerStay(Collider other)
    {
        touching = true;
        if(other.tag is "enemy") {
            mustShoot = true;
        }

    }
}
