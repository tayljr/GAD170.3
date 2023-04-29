using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bananas : MonoBehaviour
{
    public GameObject winScreen;
    public CharacterController controllerLink;
    public GameObject weapon;
    private bool win = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if enter button pressed and the level is compleated then load next level
        if(win && Input.GetKeyDown("return")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //Debug.Log("enter");
        }
    }
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "HitBox"){
        //win
        //print("you WIN");
        winScreen.SetActive(true);
        weapon.SetActive(false);
        controllerLink.enabled = false;
        win = true;
        }
    }
}
