using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private MainMethod main;
    [SerializeField] private GameObject mainMethod;
    [SerializeField] private Card attachedCard;
    [SerializeField] private GameObject dragon;
    private int startTurn;
    private int currentTurn;
    private bool traitPlayed;
    private int feildIndex;
    private bool updated;
    [SerializeField] private Transform player2DeloadSlot;
    

    private GameObject[] player1Feild;
    private GameObject[] player2Feild;


    private Transform[] lowerFeildSlots;
    private Transform[] higherFeildSlots;

    //Sprite management
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private int defaultHealth;
    private int currentHealth;
    [SerializeField] private Sprite dh5;
    [SerializeField] private Sprite dh4;
    [SerializeField] private Sprite dh3;
    [SerializeField] private Sprite dh2;
    [SerializeField] private Sprite dh1;
    [SerializeField] private Sprite ch5;
    [SerializeField] private Sprite ch4;
    [SerializeField] private Sprite ch3;
    [SerializeField] private Sprite ch2;
    [SerializeField] private Sprite ch1;

    // Start is called before the first frame update
    void Start()
    {
        lowerFeildSlots = main.GetLowerFeildSlots();
        higherFeildSlots = main.GetHigherFeildSlots();
        player1Feild = main.GetPlayer1Feild();
        player2Feild = main.GetPlayer2Feild();
        currentHealth = defaultHealth;
        updated = false;
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

        else
        {
            if (traitPlayed == false && attachedCard.GetActive() == true)
            {
                Debug.Log("EGG PLAYED");
                currentTurn = main.GetCurrentTurn();
                startTurn = main.GetCurrentTurn();
                traitPlayed = true;
            }

            else if (currentTurn != main.GetCurrentTurn() && traitPlayed == true)
            {
                currentTurn = main.GetCurrentTurn();
                Debug.Log("TURN PASSED");
            }

            if ((currentTurn - 1) == startTurn && traitPlayed == true && updated == false)
            {
                SetSprite();
                Debug.Log("CRACKING");
                updated = true;
            }

            if ((currentTurn - 2) == startTurn && traitPlayed == true)
            {
                Hatch();
            }
        }
    }

    private void SetSprite()
    {
        if ((currentTurn - 1) != startTurn)
        {
            if (attachedCard.GetHealth() == 5)
            {
                spriteRenderer.sprite = dh5;
            }

            else if (attachedCard.GetHealth() == 4)
            {
                spriteRenderer.sprite = dh4;
            }

            else if (attachedCard.GetHealth() == 3)
            {
                spriteRenderer.sprite = dh3;
            }

            else if (attachedCard.GetHealth() == 2)
            {
                spriteRenderer.sprite = dh2;
            }

            else 
            {
                spriteRenderer.sprite = dh1;
            }
        }

        else
        {
            if (attachedCard.GetHealth() == 5)
            {
                spriteRenderer.sprite = ch5;
            }

            else if (attachedCard.GetHealth() == 4)
            {
                spriteRenderer.sprite = ch4;
            }

            else if (attachedCard.GetHealth() == 3)
            {
                spriteRenderer.sprite = ch3;
            }

            else if (attachedCard.GetHealth() == 2)
            {
                spriteRenderer.sprite = ch2;
            }

            else 
            {
                spriteRenderer.sprite = ch1;
            }
        }
        
    }

    public void Hatch()
    {
        GameObject newCard = Instantiate(dragon, transform.position + Vector3.right * 26, Quaternion.identity); //Creates Dragon
        feildIndex = attachedCard.GetCurrentFeildIndex(); //Finds index of Egg

        if (attachedCard.GetAllegiance() == "Player1")
        {
            player1Feild[feildIndex] = newCard; 
            newCard.transform.position = lowerFeildSlots[feildIndex].position;
        }

        else 
        {
            player2Feild[feildIndex] = newCard;
            newCard.transform.position = player2DeloadSlot.position;;
        }

        Card newCardObject = newCard.GetComponent<Card>();   //Accesses the Card Object attached to the new card
        newCardObject.SetCurrentFeildIndex(feildIndex);   //Tells the new card what index it has been placed on 

        Destroy(gameObject);
        
    }
}
