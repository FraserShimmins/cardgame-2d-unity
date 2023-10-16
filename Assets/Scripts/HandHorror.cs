using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHorror : MonoBehaviour
{
    [SerializeField] private MainMethod main;
    [SerializeField] private GameObject mainMethod;
    [SerializeField] private Card attachedCard;
    private bool traitPlayed;
    private int currentFeild;
    private bool searching; 

    //Access to the board
    private GameObject[] player1Feild;
    private GameObject[] player2Feild;
    private Transform[] lowerFeildSlots;
    private Transform[] higherFeildSlots;

    //Sprite management
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private int defaultHealth;
    private int currentHealth;
    [SerializeField] private Sprite h1; 
    [SerializeField] private Sprite h2; 
    [SerializeField] private Sprite h3; 
    [SerializeField] private Sprite h4; 
    [SerializeField] private Sprite h5; 
    [SerializeField] private Sprite h6; 
    [SerializeField] private Sprite h7; 
    [SerializeField] private Sprite h8; 
    

    // Start is called before the first frame update
    void Start()
    {
        lowerFeildSlots = main.GetLowerFeildSlots();
        higherFeildSlots = main.GetHigherFeildSlots();
        player1Feild = main.GetPlayer1Feild();
        player2Feild = main.GetPlayer2Feild();
        searching = false;
        currentHealth = defaultHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (main.GetCurrentPlaying() == "None" && traitPlayed == false && attachedCard.GetActive() == true)
        {
            Drag();
            traitPlayed = true;
        }

        else if (traitPlayed == true && main.GetCurrentPlaying() == "Player1")
        {
            traitPlayed = false;
        }

        if (main.GetAttacking() == true)
        {
            if (currentHealth != attachedCard.GetHealth())
            {
                currentHealth = attachedCard.GetHealth();
                SetSprite();
            }
        }
    }

    public void Drag()
    {
        currentFeild = attachedCard.GetCurrentFeildIndex();
        searching = true;

        if (attachedCard.GetAllegiance() == "Player1")
        {
            if (player2Feild[currentFeild] == null)
            {
                int higherIndex = currentFeild + 1;
                int lowerIndex = currentFeild - 1;

                while (searching == true)
                {
                    if (lowerIndex >= 0 && searching == true)
                    {
                        if (player2Feild[lowerIndex] != null)
                        {
                            player2Feild[currentFeild] = player2Feild[lowerIndex];
                            player2Feild[lowerIndex].transform.position = higherFeildSlots[currentFeild].position;
                            player2Feild[currentFeild].GetComponent<Card>().SetCurrentFeildIndex(currentFeild);
                            player2Feild[lowerIndex] = null;
                            searching = false;
                            break;
                        }
                    }

                    if (higherIndex <= 4 && searching == true)
                    {
                        if (player2Feild[higherIndex] != null)
                        {
                            player2Feild[currentFeild] = player2Feild[higherIndex];
                            player2Feild[higherIndex].transform.position = higherFeildSlots[currentFeild].position;
                            player2Feild[currentFeild].GetComponent<Card>().SetCurrentFeildIndex(currentFeild);
                            player2Feild[higherIndex] = null;
                            searching = false;
                            break;
                        }
                    }

                    if ((higherIndex > 4) && (lowerIndex < 0))
                    {
                        searching = false;
                        Debug.Log("Couldnt Find foe!");
                    }

                    lowerIndex = lowerIndex - 1;
                    higherIndex = higherIndex + 1;
                }
            }
        }

        else
        {
            if (player1Feild[currentFeild] == null)
            {
                int higherIndex = currentFeild + 1;
                int lowerIndex = currentFeild - 1;

                while (searching == true)
                {
                    if (lowerIndex >= 0 && searching == true)
                    {
                        if (player1Feild[lowerIndex] != null)
                        {
                            player1Feild[currentFeild] = player1Feild[lowerIndex];
                            player1Feild[lowerIndex].transform.position = lowerFeildSlots[currentFeild].position;
                            player1Feild[currentFeild].GetComponent<Card>().SetCurrentFeildIndex(currentFeild);
                            player1Feild[lowerIndex] = null;
                            searching = false;
                            break;
                        }
                    }

                    if (higherIndex <= 4 && searching == true)
                    {
                        if (player1Feild[higherIndex] != null)
                        {
                            player1Feild[currentFeild] = player1Feild[higherIndex];
                            player1Feild[higherIndex].transform.position = lowerFeildSlots[currentFeild].position;
                            player1Feild[currentFeild].GetComponent<Card>().SetCurrentFeildIndex(currentFeild);
                            player1Feild[higherIndex] = null;
                            searching = false;
                            break;
                        }
                    }

                    if ((higherIndex > 4) && (lowerIndex < 0))
                    {
                        searching = false;
                        Debug.Log("Couldnt Find foe!");
                    }

                    lowerIndex = lowerIndex - 1;
                    higherIndex = higherIndex + 1;
                }
            }
        }
    }

    private void SetSprite()
    {
        if (attachedCard.GetHealth() == 8)
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
