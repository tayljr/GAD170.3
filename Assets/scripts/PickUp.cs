using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private bool touchingObject = false;

    // Start is called before the first frame update
    void Start()
    {
        popUpSize = new Vector2(popUpMinX, popUpMinY);
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
                itemLink.SetActive(true);
                touchingObject = false;
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
        }
    }
}
