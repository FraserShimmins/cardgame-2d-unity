using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffin : MonoBehaviour
{
    [SerializeField] private MainMethod main;
    [SerializeField] private GameObject mainMethod;
    [SerializeField] private Card attachedCard;      //The coffin card this is attached to
    [SerializeField] private GameObject vampireHorror;  //Vampire that will be played if the coffin card dies
    
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
                GameObject newCard = Instantiate(vampireHorror, transform.position + Vector3.right * 26, Quaternion.identity); //Creates vampire
                feildIndex = attachedCard.GetCurrentFeildIndex(); //Finds index of coffin

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

    private void SetSprite()
    {
        if (attachedCard.GetHealth() == 4)
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
