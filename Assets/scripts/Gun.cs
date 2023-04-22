using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private bool loaded = true;
    public Transform pointerLink;
    public float maxTurnSpeed = 100;
    public GameObject grenadePropLink;
    public GameObject rocketGrenadeLink;
    private GameObject currentGrenadeLink;
    public GameObject spawnLink;
    private Vector3 spawnLocation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = pointerLink.position - transform.position;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), maxTurnSpeed * Time.deltaTime);

        spawnLocation = spawnLink.transform.position;
        if(Input.GetMouseButtonDown(0)){
            Shoot();
        }
        if(Input.GetKeyDown("r")){
            Reload();
        }
    }
    private void Shoot(){
        if(loaded){
            loaded = false;
            grenadePropLink.SetActive(false);
            //Instantiate(contestantPrefab,new Vector3(i*2,0,0),Quaternion.identity
            currentGrenadeLink = Instantiate(rocketGrenadeLink, spawnLocation, transform.rotation);
        }
    }
    private void Reload(){
        if(loaded == false){
            loaded = true;
            grenadePropLink.SetActive(true);
        }
    }
}
