using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : ToggleBase
{
    public GameObject startPosition;
    public GameObject endPosition;
    public GameObject elevator;
    public float speed;

    private Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        elevator.transform.position = startPosition.transform.position;
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(elevator.transform.position, destination) < 0.1)
        {
            elevator.transform.position = destination;

        } else
        {
            elevator.transform.position = Vector3.Lerp(elevator.transform.position, destination, speed * Time.timeScale);
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
