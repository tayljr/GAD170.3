using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketGrenade : MonoBehaviour
{
    public float rocketSpeed = 2;
    public float explosionForce = 10f;
    public float explosionRadius = 5f;
    public GameObject explosionLink;
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
            print(collision.gameObject);
            Instantiate(explosionLink, transform.position, Quaternion.identity);
            Vector3 explosionPos = transform.position - transform.up * 0.35f;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
            foreach (Collider hit in colliders)
            {
                if(hit.gameObject.tag == "Player"){
                    hit.GetComponent<PlayerMovement>().AddImpact(explosionPos, explosionForce);
                }else{
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                    if(rb != null){
                        rb.AddExplosionForce(explosionForce, explosionPos, explosionRadius, 3.0F);
                    }
                }
            }
            Destroy(gameObject);
        }
    }
}
