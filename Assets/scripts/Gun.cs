using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private bool loaded = true;
    public Transform pointerLink;
    private float maxTurnSpeed = 100;
    public GameObject grenadePropLink;
    public GameObject rocketGrenadeLink;
    public GameObject spawnLink;
    private GameObject currentGrenadeLink;
    private Vector3 spawnLocation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotate gun towards pointer
        Vector3 direction = pointerLink.position - transform.position;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), maxTurnSpeed * Time.deltaTime);

        spawnLocation = spawnLink.transform.position;
        //when left mouse button pressed activate shoot function
        if(Input.GetMouseButtonDown(0)){
            Shoot();
        }
        //when R pressed activate reload function
        if(Input.GetKeyDown("r")){
            Reload();
        }
    }
    //shoot function that checks if the gun is loaded, and if it is loaded then creates a rocket grendade and unloads the gun.
    private void Shoot(){
        if(loaded){
            loaded = false;
            grenadePropLink.SetActive(false);
            currentGrenadeLink = Instantiate(rocketGrenadeLink, spawnLocation, transform.rotation);
        }
    }

    //relad function that checks if the gun is not loaded, if it isn't then it loads the gun
    private void Reload(){
        if(loaded == false){
            loaded = true;
            grenadePropLink.SetActive(true);
        }
    }
}
