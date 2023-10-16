using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSnake : MonoBehaviour
{
    [SerializeField] private MainMethod main;
    [SerializeField] private GameObject mainMethod;
    [SerializeField] private Card attachedCard;
    [SerializeField] private GameObject worldSnakeTailHorrorPrefab;
    [SerializeField] private GameObject worldSnakeBodyHorrorPrefab;
    private bool traitPlayed;
    private bool wrapping;
    private int total;

    //Access to the board
    private GameObject[] player1Feild;
    private GameObject[] player2Feild;
    private Transform[] lowerFeildSlots;

    //Used to indeify free slots
    private List<int> slotsToFill = new List<int>();  //List of all free slots that the card will fill
    int currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        //Setting the Game Manager
        main = mainMethod.GetComponent<MainMethod>(); //Gets the gameManager script attached to that object 
        traitPlayed = false;
        lowerFeildSlots = main.GetLowerFeildSlots();
        player1Feild = main.GetPlayer1Feild();
        player2Feild = main.GetPlayer2Feild();
    }

    // Update is called once per frame
    void Update()
    {
        if (traitPlayed == false && attachedCard.GetActive() == true)
        {
            //WorldSnakeTrait(attachedCard.GetCurrentFeildIndex());
            Debug.Log("WorldSnake PLAYED");
            WorldSnakeTrait();
            traitPlayed = true;
        }
    }

    public void WorldSnakeTrait()
    {
        int headIndex = attachedCard.GetCurrentFeildIndex();

        if (headIndex == 0)
        {
            currentIndex = 4;
        }

        else
        {
            currentIndex = headIndex - 1; //current Index we are checking
        }

        total = 0;
        wrapping = true;
        

        //Indetifying all avalible slots
        if (main.GetCurrentPlaying() == "Player1") //Player 1 playing
        {
            while (wrapping == true)
            {

                if (currentIndex == headIndex)
                {
                    wrapping = false;
                }
                
                else if (player1Feild[currentIndex] == null)
                {
                    if (total == 0)
                    {
                        GameObject newCard = Instantiate(worldSnakeTailHorrorPrefab, transform.position + Vector3.right * 26, Quaternion.identity);
                        player1Feild[currentIndex] = newCard;
                        newCard.transform.position = lowerFeildSlots[currentIndex].position;

                        Card newCardObject = newCard.GetComponent<Card>();   //Accesses the Card Object attached to the new card
                        newCardObject.SetCurrentFeildIndex(currentIndex);   //Tells the new card what index it has been placed on 
                        total = total + 1;
                    }

                    else
                    {
                        GameObject newCard = Instantiate(worldSnakeBodyHorrorPrefab, transform.position + Vector3.right * 26, Quaternion.identity);
                        player1Feild[currentIndex] = newCard;
                        newCard.transform.position = lowerFeildSlots[currentIndex].position;

                        Card newCardObject = newCard.GetComponent<Card>();   //Accesses the Card Object attached to the new card
                        newCardObject.SetCurrentFeildIndex(currentIndex);   //Tells the new card what index it has been placed on 
                        total = total + 1;
                    }
        
                }

                /*
                else
                {
                    Debug.Log("Slot " + currentIndex.ToString() + " is taken");
                }
                
                Debug.Log(currentIndex);
                */
                currentIndex = currentIndex - 1;

                if (currentIndex < 0)
                {
                    currentIndex = 4;
                }
            }
            
        }

        else //Player 2 playing
        {
            while (wrapping == true)
            {

                if (currentIndex == headIndex)
                {
                    wrapping = false;
                }
                
                else if (player2Feild[currentIndex] == null)
                {
                    if (total == 0)
                    {
                        GameObject newCard = Instantiate(worldSnakeTailHorrorPrefab, transform.position + Vector3.right * 26, Quaternion.identity);
                        player2Feild[currentIndex] = newCard;
                        newCard.transform.position = lowerFeildSlots[currentIndex].position;

                        Card newCardObject = newCard.GetComponent<Card>();   //Accesses the Card Object attached to the new card
                        newCardObject.SetCurrentFeildIndex(currentIndex);   //Tells the new card what index it has been placed on 
                        newCardObject.CardPlayed();   //Sets the card to active
                        Debug.Log("CARD ACTIVE");
                        total = total + 1;
                    }

                    else
                    {
                        GameObject newCard = Instantiate(worldSnakeBodyHorrorPrefab, transform.position + Vector3.right * 26, Quaternion.identity);
                        player2Feild[currentIndex] = newCard;
                        newCard.transform.position = lowerFeildSlots[currentIndex].position;

                        Card newCardObject = newCard.GetComponent<Card>();   //Accesses the Card Object attached to the new card
                        newCardObject.SetCurrentFeildIndex(currentIndex);   //Tells the new card what index it has been placed on 
                        newCardObject.CardPlayed();   //Sets the card to active
                        Debug.Log("CARD ACTIVE");
                        total = total + 1;
                    }
        
                }

                else
                {
                    Debug.Log("Slot " + currentIndex.ToString() + " is taken");
                }
                
                Debug.Log(currentIndex);
                currentIndex = currentIndex - 1;

                if (currentIndex < 0)
                {
                    currentIndex = 4;
                }
            }
            
        }
        
    }
    
}
