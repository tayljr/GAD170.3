using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    private int minPitch = 90;
    private int maxPitch = -60;
    private float pitch = 0.0f;
    private float yaw = 0.0f;
    private float speedV = 2.0f;
    private float speedH = 2.0f;
    private Vector3 positionOffset;
    public Camera mainCamera;
    public GameObject pointer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        positionOffset = transform.position + transform.forward * 3.5f;
        //point a line from camera center to the mose position
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        //if the ray hits something then set pointer position to the ray hit location
        if (Physics.Raycast(ray, out RaycastHit raycastHit)) {
            if(pitch < minPitch - 40 && raycastHit.distance > 8.0f){
            pointer.transform.position = raycastHit.point;
            }else{
                pointer.transform.position = positionOffset;
            }
            //Debug.Log(raycastHit.distance);
        }
        //Debug.Log(pitch);
        yaw += speedH * Input.GetAxis("Mouse X");
        //set yaw to mouse x axis, set pitch to mouse y axis while making sure pitch stays within the min and max pitch
        if(pitch > minPitch){
            pitch = minPitch;
        }else{if(pitch < maxPitch){
            pitch = maxPitch;
        }else{
            pitch -= speedV * Input.GetAxis("Mouse Y");
        }
        }
        //rotate object with pitch and yaw
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
