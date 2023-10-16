using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fortress : MonoBehaviour
{
    [SerializeField] private MainMethod main;
    [SerializeField] private GameObject mainMethod;
    [SerializeField] private Card attachedCard;      //The coffin card this is attached to
    [SerializeField] private GameObject ruins;  //Rubble that will be played if the coffin card dies
    
    //Access to the board
    private GameObject[] player1Feild;
    private GameObject[] player2Feild;
    private Transform[] lowerFeildSlots;
    private Transform[] higherFeildSlots;

    private int feildIndex;

    //Sprite management
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private int defaultHealth;
    private int currentHealth;
    [SerializeField] private Sprite h11;
    [SerializeField] private Sprite h10;
    [SerializeField] private Sprite h9;
    [SerializeField] private Sprite h8;
    [SerializeField] private Sprite h7;
    [SerializeField] private Sprite h6;
    [SerializeField] private Sprite h5;
    [SerializeField] private Sprite h4;
    [SerializeField] private Sprite h3;
    [SerializeField] private Sprite h2;
    [SerializeField] private Sprite h1;
    
    
    void Start()
    {
        main = mainMethod.GetComponent<MainMethod>(); //Gets the gameManager script attached to that object 
        lowerFeildSlots = main.GetLowerFeildSlots();
        higherFeildSlots = main.GetHigherFeildSlots();
        player1Feild = main.GetPlayer1Feild();
        player2Feild = main.GetPlayer2Feild();
        currentHealth = defaultHealth;
    }

    void Update()
    {
        if (main.GetAttacking() == true)
        {
            if (currentHealth != attachedCard.GetHealth())
            {
                currentHealth = attachedCard.GetHealth();
                SetSprite();
            }
        }
    }

    void OnDestroy()
    {
        if (gameObject.scene.isLoaded) //Was Deleted
        {
            if (main.GetAttacking() == true)
            {
                GameObject newCard1 = Instantiate(ruins, transform.position + Vector3.right * 26, Quaternion.identity); //Creates ruins
                feildIndex = attachedCard.GetCurrentFeildIndex(); //Finds index of fortress

                if (attachedCard.GetAllegiance() == "Player1")
                {
                    player1Feild[feildIndex] = newCard1; 
                    newCard1.transform.position = lowerFeildSlots[feildIndex].position;

                    if (feildIndex != 4)
                    {
                        if (player1Feild[feildIndex+1] == null)
                        {
                            GameObject newCard2 = Instantiate(ruins, transform.position + Vector3.right * 26, Quaternion.identity); //Creates ruins
                            player1Feild[feildIndex+1] = newCard2; 
                            newCard2.transform.position = lowerFeildSlots[feildIndex+1].position;

                            Card newCardObject2 = newCard2.GetComponent<Card>();   //Accesses the Card Object attached to the new card
                            newCardObject2.SetCurrentFeildIndex(feildIndex+1);   //Tells the new card what index it has been placed on 
                        }
                    }

                    if (feildIndex != 0)
                    {
                        if (player1Feild[feildIndex-1] == null)
                        {
                            GameObject newCard3 = Instantiate(ruins, transform.position + Vector3.right * 26, Quaternion.identity); //Creates ruins
                            player1Feild[feildIndex-1] = newCard3; 
                            newCard3.transform.position = lowerFeildSlots[feildIndex-1].position;

                            Card newCardObject3 = newCard3.GetComponent<Card>();   //Accesses the Card Object attached to the new card
                            newCardObject3.SetCurrentFeildIndex(feildIndex-1);   //Tells the new card what index it has been placed on 
                        }
                    }
                }

                else 
                {
                    player2Feild[feildIndex] = newCard1;
                    newCard1.transform.position = higherFeildSlots[feildIndex].position;

                    if (feildIndex != 4)
                    {
                        if (player2Feild[feildIndex+1] == null)
                        {
                            GameObject newCard2 = Instantiate(ruins, transform.position + Vector3.right * 26, Quaternion.identity); //Creates ruins
                            player2Feild[feildIndex+1] = newCard2; 
                            newCard2.transform.position = higherFeildSlots[feildIndex+1].position;

                            Card newCardObject2 = newCard2.GetComponent<Card>();   //Accesses the Card Object attached to the new card
                            newCardObject2.SetCurrentFeildIndex(feildIndex+1);   //Tells the new card what index it has been placed on 
                        }
                    }

                    if (feildIndex != 0)
                    {
                        if (player2Feild[feildIndex-1] == null)
                        {
                            GameObject newCard3 = Instantiate(ruins, transform.position + Vector3.right * 26, Quaternion.identity); //Creates ruins
                            player2Feild[feildIndex-1] = newCard3; 
                            newCard3.transform.position = higherFeildSlots[feildIndex-1].position;

                            Card newCardObject3 = newCard3.GetComponent<Card>();   //Accesses the Card Object attached to the new card
                            newCardObject3.SetCurrentFeildIndex(feildIndex-1);   //Tells the new card what index it has been placed on 
                        }
                    }
                }

                Card newCardObject1 = newCard1.GetComponent<Card>();   //Accesses the Card Object attached to the new card
                newCardObject1.SetCurrentFeildIndex(feildIndex);   //Tells the new card what index it has been placed on 
            }
        }
        
    }

    private void SetSprite()
    {
        if (attachedCard.GetHealth() == 11)
        {
            spriteRenderer.sprite = h11;
        }

        else if (attachedCard.GetHealth() == 10)
        {
            spriteRenderer.sprite = h10;
        }

        else if (attachedCard.GetHealth() == 9)
        {
            spriteRenderer.sprite = h9;
        }

        else if (attachedCard.GetHealth() == 8)
        {
            spriteRenderer.sprite = h8;
        }

        else if (attachedCard.GetHealth() == 7)
        {
            spriteRenderer.sprite = h7;
        }

        else if (attachedCard.GetHealth() == 6)
        {
            spriteRenderer.sprite = h6;
        }

        else if (attachedCard.GetHealth() == 5)
        {
            spriteRenderer.sprite = h5;
        }

        else if (attachedCard.GetHealth() == 4)
        {
            spriteRenderer.sprite = h4;
        }

        else if (attachedCard.GetHealth() == 3)
        {
            spriteRenderer.sprite = h3;
        }

        else if (attachedCard.GetHealth() == 2)
        {
            spriteRenderer.sprite = h2;
        }

        else 
        {
            spriteRenderer.sprite = h1;
        }
    }
}
