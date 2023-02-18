using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : ToggleBase
{
    public GameObject startPosition;
    public GameObject endPosition;
    public float speed;

    private Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPosition.transform.position;
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, destination) < 0.1)
        {
            transform.position = destination;

        } else
        {
            transform.position = Vector3.Lerp(transform.position, destination, speed * Time.timeScale);
        }
    }

    override public void Toggle()
    {
        if (destination == startPosition.transform.position)
        {
            destination = endPosition.transform.position;
        } else
        {
            destination = startPosition.transform.position;
        }
    }
}
