using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision){
        Destroy(collision.gameObject);
        Debug.Log("*PAIN*");
    }

    void OnTriggerEnter(Collider collision){
        if(collision.gameObject.name == "Player"){
            Debug.Log("yayy");
        }
    }
}
