using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int minPitch = 90;
    public int maxPitch = -50;
    public float pitch = 0.0f;
    public float yaw = 0.0f;
    public float speedV = 2.0f;
    public float speedH = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(pitch);
        yaw += speedH * Input.GetAxis("Mouse X");
        if(pitch > minPitch){
            pitch = minPitch;
        }else{if(pitch < maxPitch){
            pitch = maxPitch;
        }
        pitch -= speedV * Input.GetAxis("Mouse Y");
        }
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
