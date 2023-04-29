using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lego : MonoBehaviour
{
    public GameObject endScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //when a player enters the trigger, start function with timer
    void OnTriggerEnter(Collider collision){
        if(collision.gameObject.tag == "Player"){
        //death
        StartCoroutine(Death());
        }
    }

    //a function with a timer that activates a death screen and waits untill the player presses enter then reloads the scene
    private IEnumerator Death(){
        //print("death");
        endScreen.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown("return"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
