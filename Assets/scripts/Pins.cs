using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pins : MonoBehaviour
{
    public GameObject pinsLink;
    private GameObject currentPins;

    // Start is called before the first frame update
    void Start()
    {
        //add this script to event bus
        EventBus.Current.SpawnPins += SpawnPins;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //when event called ...
    private void SpawnPins(){
        // ... destroy previous pin set and create a new one
        Destroy(currentPins);
        currentPins = Instantiate(pinsLink, transform.position, Quaternion.identity);
    }
}
