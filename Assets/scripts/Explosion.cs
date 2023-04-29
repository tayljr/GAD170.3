using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private bool hitPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        hitPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //public function that controlls an explosion
    public void onExplode(GameObject exploLink, Vector3 exploPos, float exploForce, float exploRadius){
        //create explosion particle effect
        Instantiate(exploLink, exploPos, Quaternion.identity);
        //create an overlap sphere the detects any objects it touches
        Collider[] colliders = Physics.OverlapSphere(exploPos, exploRadius);
        //for each object the sphere touches ...
        foreach (Collider hit in colliders){
                // ... if the object has the player tag then call the impact function on the players script
                if(hit.gameObject.tag == "Player" && hitPlayer == false){
                    hit.GetComponent<PlayerMovement>().AddImpact(exploPos - transform.up * 0.35f - transform.right * 0.8f, exploForce);
                    //Debug.Log("player hit");
                    hitPlayer = true;
                }else{
                    //tried creating chain explosions but diddn't work :( this was my attempt:
                    /*if(hit.gameObject.tag == "Explosive" && hit.gameObject != gameObject){
                        //this makes chain explosions all the same
                        //need to figure out how to set values for different objects
                        Destroy(hit.gameObject);
                        Vector3 newPos = hit.gameObject.transform.position;
                        hit.GetComponent<Explosion>().onExplode(exploLink, newPos, exploForce, exploRadius);
                        //onExplode(exploLink, 0.5f, newPos, exploForce, exploRadius);
                    }else{*/
                    if(hit.gameObject.tag != "HitBox" && hit.gameObject.tag != "Projectile" && hit.gameObject.tag != "Weapon"){
                        //add explosion force to object's rigidbodies
                        Rigidbody rb = hit.GetComponent<Rigidbody>();
                        if(rb != null){
                            Debug.Log(hit.gameObject + " hit");
                            rb.AddExplosionForce(exploForce, exploPos, exploRadius, 3.0f);
                            //}
                        }
                    }
                }
            //}
        }
        //destroy this game object at the end
        Destroy(gameObject);
    }
}
