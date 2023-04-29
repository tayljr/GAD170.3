using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    private void Awake()
    {
        //at the start make sure there is only one of these
        if (_current != null && _current != this)
        {
            Destroy(this.gameObject);
        } else {
            _current = this;
            //Adding this line to the awake on our previous example will make it IMMORTAL
            //DontDestroyOnLoad(gameObject);
        }
    }

    private static EventBus _current;
    public static EventBus Current { get { return _current; } }

    //spawn pins event
    public event Action SpawnPins;
    public void SpawnTrigger(){
        //Debug.Log("spawned");
        SpawnPins();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
