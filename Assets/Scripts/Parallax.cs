using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Parallax : MonoBehaviour
{
    private float length, startpos, campos;

    public GameObject cam;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {

        transform.position = cam.transform.position;
        startpos = transform.position.x;
       
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        Debug.Log(length);
        
    }

    
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x - campos) * (1 - parallaxEffect);
        float dist = (cam.transform.position.x - campos) * parallaxEffect;

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.y);

        if (temp > startpos + length)
        {
            startpos += length;
        } else if (temp < startpos - length)
        {
            startpos -= length;
        }
        
    }
}
