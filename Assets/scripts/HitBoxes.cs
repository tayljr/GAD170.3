using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxes : MonoBehaviour
{
    public GameObject targetLink;
    public Vector3 targetLocation;
    // Start is called before the first frame update
    void Start()
    {
        targetLocation = targetLink.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        targetLocation = targetLink.transform.position;
        transform.position = targetLocation;
    }
}
