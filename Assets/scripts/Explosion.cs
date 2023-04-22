using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    //public float explosionForce = 10f;
    //public float explosionRadius = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void onExplode(GameObject exploLink, float exploForce, float exploRadius){
        Instantiate(exploLink, transform.position, Quaternion.identity);
        //thisExplosion.GetComponent<Explosion>().onExplode(explosionForce, explosionRadius);
        
        Vector3 exploPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(exploPos, exploRadius);
        foreach (Collider hit in colliders){
            if(hit.gameObject.tag == "Player"){
                hit.GetComponent<PlayerMovement>().AddImpact(exploPos - transform.up * 0.35f - transform.right * 0.8f, exploForce);
            }else{
                if(hit.gameObject.tag == "Explosive"){
                    //this makes chain explosions all the same
                    //need to figure out how to set values for different objects
                    hit.GetComponent<Explosion>().onExplode(exploLink, exploForce, exploRadius);
                }else{
                    Rigidbody rb = hit.GetComponent<Rigidbody>();
                    if(rb != null){
                        rb.AddExplosionForce(exploForce, exploPos, exploRadius, 3.0f);
                    }
                }
            }
        }
        Destroy(gameObject);
    }
}
