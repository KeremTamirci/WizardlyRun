using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySlime : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;
    public GameObject heart5;

    public int lives = 5;

    void OnCollisionEnter(Collision collider)
    {
        if (collider.collider.tag is "sphere"){
            lives--;
            if (lives <= 0){
                Destroy(gameObject);
            }
        }
        switch(lives){
            case 4:
            heart1.SetActive(false);
            break;
            case 3:
            heart2.SetActive(false);
            break;
            case 2:
            heart3.SetActive(false);
            break;
            case 1:
            heart4.SetActive(false);
            break;
        }
    }
}
