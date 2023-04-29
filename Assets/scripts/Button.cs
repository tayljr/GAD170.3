using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Vector2 popUpSize = new Vector2(0.0f, 0.0f);
    public GameObject popUpLink;
    private bool touchingObject = false;
    public GameObject winScreen;
    public CharacterController controllerLink;
    public GameObject weapon;
    // Start is called before the first frame update
    void Start()
    {
        //when this object starts trigger the event on the event bus, activate win popup, deactivate weapon and disable player controller
        EventBus.Current.SpawnTrigger();
        winScreen.SetActive(true);
        weapon.SetActive(false);
        controllerLink.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if the enter button is pushed then deactivate win popup, activate weapon and enable player controller
        if(Input.GetKeyDown("return")){
            winScreen.SetActive(false);
            weapon.SetActive(true);
            controllerLink.enabled = true;
        }
        popUpLink.GetComponent< RectTransform >( ).sizeDelta = popUpSize;
        //if player is touching object then increase size of popup to max
        if(touchingObject){
            if(popUpSize.x < 250.0f){
            popUpSize.x += 5.0f;
            }
            if(popUpSize.y < 70.0f){
            popUpSize.y += 5.0f;
            }
            //if player is touching object and presses e then activate the event on the event bus
            if(Input.GetKeyDown("e")){
                //Debug.Log("e");
                EventBus.Current.SpawnTrigger();
            }
        //if player is not touching object then decreas size of popup to min
        }else{
            if(popUpSize.x > 0.0f){
                popUpSize.x -= 5.0f;
            }
            if(popUpSize.y > 0.0f){
                popUpSize.y -= 5.0f;
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
}
