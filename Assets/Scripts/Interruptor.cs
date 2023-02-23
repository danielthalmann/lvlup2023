using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour
{
    
    public List<ToggleBase> toggles = new List<ToggleBase>();

    public void ToggleInterruptor()
    {
        foreach(ToggleBase toggle in toggles)
        {
            toggle.Toggle();
        }
    }

}
