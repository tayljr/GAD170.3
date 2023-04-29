using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketGrenade : MonoBehaviour
{
    private float rocketSpeed = 40f;
    private float explosionForce = 400f;
    private float explosionRadius = 10f;
    public GameObject explosionLink;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move forward every frame
        transform.Translate(Vector3.forward * rocketSpeed * Time.deltaTime);
    }

    //function that creates an explosion when this collides with something
    void OnTriggerEnter(Collider collision){
        if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "Weapon" && collision.gameObject.tag != "HitBox" || collision.gameObject.tag == "Terrain"){
            //Debug.Log(collision.gameObject);
            this.GetComponent<Explosion>().onExplode(explosionLink, transform.position, explosionForce, explosionRadius);
        }
    }
}
