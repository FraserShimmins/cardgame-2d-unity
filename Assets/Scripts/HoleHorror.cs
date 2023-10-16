using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleHorror : MonoBehaviour
{
    [SerializeField] private MainMethod main;
    [SerializeField] private GameObject mainMethod;
    [SerializeField] private Card attachedCard;      //The Hole card this is attached to

    //Access to the board
    private GameObject[] player1Feild;
    private GameObject[] player2Feild;

    private int feildIndex;

    // Start is called before the first frame update
    void Start()
    {
        player1Feild = main.GetPlayer1Feild();
        player2Feild = main.GetPlayer2Feild();
    }

    //FIX THIS LATER
    void OnDestroy()
    {
        if (gameObject.scene.isLoaded) //Was Deleted
        {
            if (main.GetAttacking() == true)
            {
                feildIndex = attachedCard.GetCurrentFeildIndex(); //Finds index of hole

                if (attachedCard.GetAllegiance() == "Player1")
                {
                    if (player2Feild[feildIndex] != null)
                    {
                        if ((player2Feild[feildIndex].GetComponent<Sheild>() != null) && (player2Feild[feildIndex].GetComponent<Sheild>().GetTrait() == false)) //Sheild Hero will firm the hit
                        {
                            player2Feild[feildIndex].GetComponent<Sheild>().PlayTrait();
                        }

                        else
                        {
                            Destroy(player2Feild[feildIndex]);
                        }
    
                    }
                }

                else 
                {
            
                    if (player1Feild[feildIndex] != null)
                    {
                        Debug.Log("HOLE");

                        if ((player1Feild[feildIndex].GetComponent<Sheild>() != null) && (player1Feild[feildIndex].GetComponent<Sheild>().GetTrait() == false))
                        {
                            player1Feild[feildIndex].GetComponent<Sheild>().PlayTrait();
                            Debug.Log("MISSED!");
                        }

                        else
                        {
                            Destroy(player1Feild[feildIndex]);
                            Debug.Log("HIT!");
                        }
                       
                    }
                }

            }
        }
    }
}
