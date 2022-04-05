using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject follow;
    Vector3 _delta = new Vector3(0, 8.0f, 5.0f);
    RaycastHit hit;
    
    void Start()
    {
        follow = GameObject.FindGameObjectWithTag("Character");
    }

    void Update()
    {
        CheckObj();
    }

    void CheckObj()
    {
        Debug.DrawRay(transform.position, follow.transform.position - transform.position, Color.red);
        if (Physics.Raycast(transform.position, follow.transform.position - transform.position, out hit))
        {
            //TODO
        }
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, follow.transform.position + _delta, 10.0f * Time.deltaTime);
    }
}
