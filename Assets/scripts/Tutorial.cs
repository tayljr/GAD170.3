using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Tutorial : MonoBehaviour
{
    public VideoPlayer vpLink;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if enter button pressed then skip to the end of the video
        if(Input.GetKeyDown("return")){
            vpLink.frame = 360;
        }
    }
}
