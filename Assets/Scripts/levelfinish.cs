using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelfinish : MonoBehaviour
{
    public string menuSceneName = "Menu";

    private int count = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Brute" || collision.tag == "Bon" || collision.tag == "Truand")
        {
            count++;
        }

        if (count == 3)
            SceneManager.LoadScene(menuSceneName);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Brute" || collision.tag == "Bon" || collision.tag == "Truand")
        {
            count--;
        }

    }

}
