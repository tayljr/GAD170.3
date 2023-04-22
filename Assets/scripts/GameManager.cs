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
        for(int i = 0;i<disableOnStart.Count;i++){
            disableOnStart[i].SetActive(false);
        }

        for(int i = 0;i<enableOnStart.Count;i++){
            enableOnStart[i].SetActive(true);
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
