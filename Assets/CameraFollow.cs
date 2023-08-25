using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform wizard;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - wizard.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = wizard.position + offset;
        targetPos.x = -0.4f;
        transform.position = targetPos;
    }
}
