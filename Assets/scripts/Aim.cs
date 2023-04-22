using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public int minPitch = 90;
    public int maxPitch = -50;
    private float pitch = 0.0f;
    private float yaw = 0.0f;
    public float speedV = 2.0f;
    public float speedH = 2.0f;
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
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
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
        if(pitch > minPitch){
            pitch = minPitch;
        }else{if(pitch < maxPitch){
            pitch = maxPitch;
        }else{
            pitch -= speedV * Input.GetAxis("Mouse Y");
        }
        }
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
