using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketGrenade : MonoBehaviour
{
    public float rocketSpeed = 2;
    public float explosionForce = 10f;
    public float explosionRadius = 5f;
    public float left = 0.8f;
    public GameObject explosionLink;
    private GameObject thisExplosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * rocketSpeed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider collision){
        if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "Weapon" || collision.gameObject.tag == "Terrain"){
            //print(collision.gameObject);
            this.GetComponent<Explosion>().onExplode(explosionLink, explosionForce, explosionRadius);
            /*thisExplosion = Instantiate(explosionLink, transform.position, Quaternion.identity);
            //thisExplosion.GetComponent<Explosion>().onExplode(explosionForce, explosionRadius);
            
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
            foreach (Collider hit in colliders)
            {
                if(hit.gameObject.tag == "Player"){
                    hit.GetComponent<PlayerMovement>().AddImpact(explosionPos - transform.up * 0.35f - transform.right * left, explosionForce);
                }else{
                    if(hit.gameObject.tag == "Explosive"){
                        
                    }
                    Rigidbody rb = hit.GetComponent<Rigidbody>();
                    if(rb != null){
                        rb.AddExplosionForce(explosionForce, explosionPos, explosionRadius, 3.0F);
                        }
                }
            }
            
            Destroy(gameObject);
            */
        }
    }
    /*
    public void onExplode(){
            thisExplosion = Instantiate(explosionLink, transform.position, Quaternion.identity);
            //thisExplosion.GetComponent<Explosion>().onExplode(explosionForce, explosionRadius);
            
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
            foreach (Collider hit in colliders)
            {
                if(hit.gameObject.tag == "Player"){
                    hit.GetComponent<PlayerMovement>().AddImpact(explosionPos - transform.up * 0.35f - transform.right * left, explosionForce);
                }else{
                    if(hit.gameObject.tag == "Explosive"){
                        hit.GetC
                    }
                    Rigidbody rb = hit.GetComponent<Rigidbody>();
                    if(rb != null){
                        rb.AddExplosionForce(explosionForce, explosionPos, explosionRadius, 3.0F);
                        }
                }
            }
            Destroy(gameObject);
    }*/
}
