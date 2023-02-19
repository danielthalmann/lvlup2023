using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwap : MonoBehaviour
{
    public Rigidbody2D character;
    public List<Rigidbody2D> availableChar;
    public int whichChar;
    // Start is called before the first frame update
    void Start()
    {
        if (character == null && availableChar.Count >= 1)
            character = availableChar[0];
        Swap();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (whichChar == 0)
                whichChar = availableChar.Count - 1;
            else
                whichChar -= 1;
            Swap();
        }
    }

    /// <summary>
    ///Recupere le charactere actuellement en main du joueur et desactive ceux qui ne le sont pas
    /// </summary>
    void Swap()
    {
        character = availableChar[whichChar];
        character.GetComponent<Movement>().enabled = true;
        for (int i = 0; i <= availableChar.Count; i++)
        {
            Debug.Log(availableChar[i]);
            if (availableChar[i] != character)
            {
                availableChar[i].GetComponent<Movement>().enabled = false;
                if (availableChar[i].tag == "Truand")
                {
                    availableChar[i].GetComponent<Shooting>().enabled = false;
                    availableChar[i].GetComponent<Movement>().enabled = false;
                }
                else if (availableChar[i].tag == "Brute")
                {
                    availableChar[i].GetComponent<Breakable>().enabled = false;
                    availableChar[i].GetComponent<Movement>().enabled = false;
                }    
                availableChar[i].velocity = new Vector2(0.0f, 0.0f);
                Physics2D.IgnoreCollision(character.GetComponent<Collider2D>(), availableChar[i].GetComponent<Collider2D>(), true);
            }
            else if (availableChar[i] == character)
            {
                availableChar[i].GetComponent<Movement>().enabled = true;
                if (availableChar[i].tag == "Truand")
                    availableChar[i].GetComponent<Shooting>().enabled = true;
                else if (availableChar[i].tag == "Brute")
                    availableChar[i].GetComponent<Breakable>().enabled = true;
                availableChar[i].velocity = new Vector2(0.0f, 0.0f);
                Physics2D.IgnoreCollision(character.GetComponent<Collider2D>(), availableChar[i].GetComponent<Collider2D>(), false);
            }
        }
    }
}
