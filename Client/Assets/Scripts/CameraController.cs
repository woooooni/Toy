using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject follow;
    Vector3 _delta = new Vector3(0, 5, 3);
    
    void Start()
    {
        follow = GameObject.FindGameObjectWithTag("Character");
    }

    void Update()
    {
        
    }

    void LateUpdate() 
    {
        transform.position = follow.transform.position + _delta;
    }
}
