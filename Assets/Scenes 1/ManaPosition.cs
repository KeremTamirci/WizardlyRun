using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPosition : MonoBehaviour
{
    public Vector3 righttop;
    public Vector3 leftbottom;
    public double ydif;
    public double bigy;
    public float ypos;
    // Start is called before the first frame update
    void Start()
    {
        righttop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        bigy = righttop[2];
        Debug.Log(righttop);
        Camera.main.ScreenToWorldPoint(Vector3.zero);
        ydif = (righttop[2] - leftbottom[2]);
        //float ypos = (float)(bigy+0*(ydif));
        float ypos = Screen.height-200;
        transform.position = new Vector3(transform.position.x, ypos, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {

    }
}

