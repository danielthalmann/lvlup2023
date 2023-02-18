using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class followCam : MonoBehaviour
{

    public GameObject cam;

    private float left;

    // Start is called before the first frame update
    void Start()
    {
        left = cam.transform.position.x - transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.position = new Vector3(cam.transform.position.x - left, transform.position.y, transform.position.z);
        
    }
}
