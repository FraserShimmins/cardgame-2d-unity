using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlot : MonoBehaviour
{
    [SerializeField] private MainMethod main;
    [SerializeField] private GameObject mainMethod;
    [SerializeField] private int index;
    [SerializeField] private bool player1CurrentlyUsed;
    [SerializeField] private bool player2CurrentlyUsed;

    // Start is called before the first frame update
    void Start()
    {
        //Setting the Game Manager
        main = mainMethod.GetComponent<MainMethod>(); //Gets the gameManager script attached to that object 

        player1CurrentlyUsed = false;
        player2CurrentlyUsed = false;
    }

    void OnMouseDown()
    {
        if (main.GetCurrentPlaying() == "Player1")
        {
            // If player is trying to play card & slot is free
            if (main.GetFocused() == true)
            {
                main.PlayCard(gameObject, index);
                player1CurrentlyUsed = true;
            }
        }
        
        else
        {
            // If player is trying to play card & slot is free
            if (main.GetFocused() == true)
            {
                main.PlayCard(gameObject, index);
                player2CurrentlyUsed = true;
            }
        }
    }

    //Slot is made free for whatever reason
    public void Player1FreeUpSlot()
    {
        player1CurrentlyUsed = false;
    }

    public void Player2FreeUpSlot()
    {
        player2CurrentlyUsed = false;
    }

}
