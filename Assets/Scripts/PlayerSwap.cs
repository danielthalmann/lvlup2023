using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwap : MonoBehaviour
{
    public List<PlayerControl> players;

    public int currentPlayer;
    public CamTarget camTaget;

    // Start is called before the first frame update
    void Start()
    {
        currentPlayer = 0;
        Swap();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentPlayer = ++currentPlayer % players.Count;
            Swap();
        }
    }

    /// <summary>
    ///Recupere le charactere actuellement en main du joueur et desactive ceux qui ne le sont pas
    ///Le premier qui touche a ce script et le casse, se demmerde avec
    /// </summary>
    void Swap()
    {
        players[currentPlayer].enabled = true;

        for (int i = 0; i < players.Count; i++)
        {
            if (i == currentPlayer)
                players[i].enabled = true;
            else
                players[i].enabled = false;
        }

        camTaget.target = players[currentPlayer].gameObject.transform;
    }
}
