using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> disableOnStart;
    public List<GameObject> enableOnStart;
    
    // Start is called before the first frame update
    void Start()
    {
        //deactivate objects on start
        for(int i = 0;i<disableOnStart.Count;i++){
            if(disableOnStart[i].activeSelf == true){
                disableOnStart[i].SetActive(false);
            }
        }

        //acticate objects on start
        for(int i = 0;i<enableOnStart.Count;i++){
            if(enableOnStart[i].activeSelf == false){
                enableOnStart[i].SetActive(true);
            }
        }

        //hide curser and locks it to middle of screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
