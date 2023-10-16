using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSpell : MonoBehaviour
{
    [SerializeField] private MainMethod main;
    [SerializeField] private GameObject mainMethod;
    [SerializeField] private Card attachedCard;
    private bool traitPlayed;
    private int lowerIndex;
    private int higherIndex;

    //Access to the board
    private GameObject[] player1Feild;
    private GameObject[] player2Feild;
    private Transform[] lowerFeildSlots;



    // Start is called before the first frame update
    void Start()
    {
        //Setting the Game Manager
        main = mainMethod.GetComponent<MainMethod>(); //Gets the gameManager script attached to that object 
        traitPlayed = false;
        lowerFeildSlots = main.GetLowerFeildSlots();
        player1Feild = main.GetPlayer1Feild();
        player2Feild = main.GetPlayer2Feild();

        lowerIndex = 0;
        higherIndex = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (traitPlayed == false && attachedCard.GetActive() == true)
        {
            Gust();
            traitPlayed = true;
        }
    }

    public void Gust()
    {
        int spellIndex = attachedCard.GetCurrentFeildIndex();

        //Indetifying all avalible slots
        if (main.GetCurrentPlaying() == "Player1") //Player 1 playing
        {
            while (lowerIndex != spellIndex)
            {
                if (player1Feild[lowerIndex] != null)
                {
                    if (lowerIndex != 0)
                    {
                        if (player1Feild[lowerIndex-1] == null)
                        {
                            player1Feild[lowerIndex-1] = player1Feild[lowerIndex];
                            player1Feild[lowerIndex].transform.position = lowerFeildSlots[(lowerIndex-1)].position;
                            player1Feild[lowerIndex-1].GetComponent<Card>().SetCurrentFeildIndex(lowerIndex-1);
                            player1Feild[lowerIndex] = null;
                        }
                    }
                }
                
                lowerIndex += 1;   
            }

            while (higherIndex != spellIndex)
            {
                if (player1Feild[higherIndex] != null)
                {
                    if (higherIndex != 4)
                    {
                        if (player1Feild[higherIndex+1] == null)
                        {
                            player1Feild[higherIndex+1] = player1Feild[higherIndex];
                            player1Feild[higherIndex].transform.position = lowerFeildSlots[(higherIndex+1)].position;
                            player1Feild[higherIndex+1].GetComponent<Card>().SetCurrentFeildIndex(higherIndex+1);
                            player1Feild[higherIndex] = null;
                        }
                    }
                }

                higherIndex -= 1;   
            }
        }

        else //Player 2 playing
        {
            while (lowerIndex != spellIndex)
            {
                if (player2Feild[lowerIndex] != null)
                {
                    if (lowerIndex != 0)
                    {
                        if (player2Feild[lowerIndex-1] == null)
                        {
                            player2Feild[lowerIndex-1] = player2Feild[lowerIndex];
                            player2Feild[lowerIndex].transform.position = lowerFeildSlots[(lowerIndex-1)].position;
                            player2Feild[lowerIndex-1].GetComponent<Card>().SetCurrentFeildIndex(lowerIndex-1);
                            player2Feild[lowerIndex] = null;
                        }
                    }
                }
                
                lowerIndex += 1;   
            }

            while (higherIndex != spellIndex)
            {
                if (player2Feild[higherIndex] != null)
                {
                    if (higherIndex != 4)
                    {
                        if (player2Feild[higherIndex+1] == null)
                        {
                            player2Feild[higherIndex+1] = player2Feild[higherIndex];
                            player2Feild[higherIndex].transform.position = lowerFeildSlots[(higherIndex+1)].position;
                            player2Feild[higherIndex+1].GetComponent<Card>().SetCurrentFeildIndex(higherIndex+1);
                            player2Feild[higherIndex] = null;
                        }
                    }
                }

                higherIndex -= 1;   
            }
        }
    
        
    }
}
