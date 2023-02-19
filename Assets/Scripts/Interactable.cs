using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool         isInRange;
    public KeyCode      interactKey;
    public UnityEvent   interactAction;

    void    Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey)) 
            {
                interactAction.Invoke();
            }
        }
    }

    //Chopper le gameobject mur, detruire ce mur ainsi que sa visiblite-

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Brute"))
        {
            isInRange= true;
            Debug.Log("Brute is in range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange= false;
            Debug.Log("Brute out range");
        }
    }
}
