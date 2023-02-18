using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour
{
    
    public List<ToggleBase> toggles = new List<ToggleBase>();
    private bool canToggle;

    // Start is called before the first frame update
    void Start()
    {
        canToggle = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canToggle)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                foreach(ToggleBase toggle in toggles)
                {
                    toggle.Toggle();
                }
            }
             
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);

        if (collision.tag == "Player")
        {
            Debug.Log("interruptor in");
            canToggle = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            Debug.Log("interruptor out");
            canToggle = false;
        }

    }
}
