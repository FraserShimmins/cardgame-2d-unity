using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trojan : MonoBehaviour
{
    [SerializeField] private MainMethod main;
    [SerializeField] private GameObject mainMethod;
    [SerializeField] private Card attachedCard;      //The trojan horse card this is attached to
    [SerializeField] private GameObject greekHiderHero;  //Greek that will be played if the trojan horse card dies
    
    //Access to the board
    private GameObject[] player1Feild;
    private GameObject[] player2Feild;
    private Transform[] lowerFeildSlots;
    private Transform[] higherFeildSlots;

    private int feildIndex;
    
    void Start()
    {
        main = mainMethod.GetComponent<MainMethod>(); //Gets the gameManager script attached to that object 
        lowerFeildSlots = main.GetLowerFeildSlots();
        higherFeildSlots = main.GetHigherFeildSlots();
        player1Feild = main.GetPlayer1Feild();
        player2Feild = main.GetPlayer2Feild();
    }

    void OnDestroy()
    {
        if (gameObject.scene.isLoaded) //Was Deleted
        {
            if (main.GetAttacking() == true)
            {
                GameObject newCard = Instantiate(greekHiderHero, transform.position + Vector3.right * 26, Quaternion.identity); //Creates zombie
                feildIndex = attachedCard.GetCurrentFeildIndex(); //Finds index of tomb

                if (attachedCard.GetAllegiance() == "Player1")
                {
                    player1Feild[feildIndex] = newCard; 
                    newCard.transform.position = lowerFeildSlots[feildIndex].position;
                }

                else 
                {
                    player2Feild[feildIndex] = newCard;
                    newCard.transform.position = higherFeildSlots[feildIndex].position;
                }

                Card newCardObject = newCard.GetComponent<Card>();   //Accesses the Card Object attached to the new card
                newCardObject.SetCurrentFeildIndex(feildIndex);   //Tells the new card what index it has been placed on 
            }
        }
    }
}
