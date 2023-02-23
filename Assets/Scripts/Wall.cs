using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public bool open;
    
    public GameObject openObject;
    public GameObject closeObject;

    private Collider2D col;


    void Start()
    { 
        col = GetComponent<Collider2D>();
        openObject.SetActive(open);
        closeObject.SetActive(!open);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        openObject.SetActive(open);
        closeObject.SetActive(!open);

        col.enabled = !open;

    }

    public void openWall()
    {
        open = true;
    }
}
