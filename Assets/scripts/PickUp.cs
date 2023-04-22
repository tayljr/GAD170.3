using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PickUp : MonoBehaviour
{
    public float rotateSpeed = 150f;
    public float popUpMinX = 0.0f;
    public float popUpMinY = 0.0f;
    public float popUpMaxX = 250.0f;
    public float popUpMaxY = 70.0f;
    public float popUpSpeed = 50.0f;
    public Vector2 popUpSize;
    public GameObject itemLink;
    public GameObject popUpLink;
    public GameObject tutorialLink;
    public GameObject aimerLink;
    public VideoPlayer vpLink;
    public CharacterController controllerLink;
    private bool touchingObject = false;

    // Start is called before the first frame update
    void Start()
    {
        popUpSize = new Vector2(popUpMinX, popUpMinY);
        vpLink.loopPointReached += CheckOver;
    }

    // Update is called once per frame
    void Update()
    {
        popUpLink.GetComponent< RectTransform >( ).sizeDelta = popUpSize;
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        if(touchingObject){
            if(popUpSize.x < popUpMaxX){
            popUpSize.x += popUpSpeed;
            }
            if(popUpSize.y < popUpMaxY){
            popUpSize.y += popUpSpeed;
            }
            if(Input.GetKeyDown("e")){
                //Debug.Log("e");
                touchingObject = false;
                tutorialLink.SetActive(true);
                controllerLink.enabled = false;
                gameObject.SetActive(false);
            }
        }else{
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
            //for(tutorialLink.activeSelf){
            //if(Input.GetKeyDown("return")){
            //    print("Enter");
            //}
            //}
        }
    }
    
    void CheckOver(UnityEngine.Video.VideoPlayer vp){
        itemLink.SetActive(true);
        tutorialLink.SetActive(false);
        controllerLink.enabled = true;
    }
}
