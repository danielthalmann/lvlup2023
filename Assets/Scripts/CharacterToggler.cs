using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterToggler : MonoBehaviour
{

    private bool canToggle;
    List<IToggle> toggles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canToggle)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                foreach(var toggle in toggles)
                {
                    toggle.Toggle();
                }
            }
             
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Interruptor")
        {
            canToggle = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Interruptor")
        {
            canToggle = false;
        }

    }
}
