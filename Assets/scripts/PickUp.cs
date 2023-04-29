using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PickUp : MonoBehaviour
{
    private float rotateSpeed = 150f;
    private float popUpMinX = 0.0f;
    private float popUpMinY = 0.0f;
    private float popUpMaxX = 250.0f;
    private float popUpMaxY = 70.0f;
    private float popUpSpeed = 5.0f;
    private Vector2 popUpSize;
    public GameObject itemLink;
    public GameObject popUpLink;
    public GameObject tutorialLink;
    public VideoPlayer vpLink;
    public CharacterController controllerLink;
    private bool touchingObject = false;

    // Start is called before the first frame update
    void Start()
    {
        //set interact popup size to minimum
        popUpSize = new Vector2(popUpMinX, popUpMinY);
        vpLink.loopPointReached += CheckOver;
    }

    // Update is called once per frame
    void Update()
    {
        popUpLink.GetComponent< RectTransform >( ).sizeDelta = popUpSize;
        //constat rotaion
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        
        //if player is touching object then increase size of popup to max
        if(touchingObject){
            if(popUpSize.x < popUpMaxX){
            popUpSize.x += popUpSpeed;
            }
            if(popUpSize.y < popUpMaxY){
            popUpSize.y += popUpSpeed;
            }
            //if player is touching object and presses e then activate tutorial, deactivate chactater controller and deactivate itself
            if(Input.GetKeyDown("e")){
                //Debug.Log("e");
                touchingObject = false;
                tutorialLink.SetActive(true);
                controllerLink.enabled = false;
                gameObject.SetActive(false);
            }
        }else{
        //if player is not touching object then decreas size of popup to min
            if(popUpSize.x > popUpMinX){
                popUpSize.x -= popUpSpeed;
            }
            if(popUpSize.y > popUpMinY){
                popUpSize.y -= popUpSpeed;
            }
        }
    }

    void OnTriggerEnter(Collider collisionLink){
        //Debug.Log(collisionLink);
        //Debug.Log(collisionLink.gameObject.tag);
        if(collisionLink.gameObject.tag == "Player"){
            //Debug.Log("player");
            touchingObject = true;
        }
    }

    void OnTriggerExit(Collider collisionLink){
        if(collisionLink.gameObject.tag == "Player"){
            touchingObject = false;
        }
    }

    //when this object is disabled shrink popup to minimum
    void OnDisable(){
        for(int i = 0; i < popUpSize.x; i++){
            //disapear
            if(popUpSize.x > popUpMinX){
                popUpSize.x -= popUpSpeed;
            }
                if(popUpSize.y > popUpMinY){
                popUpSize.y -= popUpSpeed;
            }
            popUpLink.GetComponent< RectTransform >( ).sizeDelta = popUpSize;
        }
    }
    
    //when video finishes activate the item linked, disable the tutorial and enable the controller
    void CheckOver(UnityEngine.Video.VideoPlayer vp){
        itemLink.SetActive(true);
        tutorialLink.SetActive(false);
        controllerLink.enabled = true;
    }
}
