using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorMan : MonoBehaviour
{
    [SerializeField] private MainMethod main;
    [SerializeField] private GameObject mainMethod;
    [SerializeField] private Card attachedCard;
    private int maxDamagePossible;
    private bool traitPlayed;

    //Access to the board
    private GameObject[] player1Feild;
    private GameObject[] player2Feild;

    //Sprites
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite defaultMirrorMan; 
    [SerializeField] private Sprite d0; 
    [SerializeField] private Sprite d1; 
    [SerializeField] private Sprite d2; 
    [SerializeField] private Sprite d3; 
    [SerializeField] private Sprite d4; 
    [SerializeField] private Sprite d5; 
    [SerializeField] private Sprite d6; 
    [SerializeField] private Sprite d7; 
    [SerializeField] private Sprite d8; 
    [SerializeField] private Sprite d9; 
    [SerializeField] private Sprite d10; 
    [SerializeField] private Sprite d11; 
    [SerializeField] private Sprite d14;

    // Start is called before the first frame update
    void Start()
    {
        player1Feild = main.GetPlayer1Feild();
        player2Feild = main.GetPlayer2Feild();
        maxDamagePossible = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (main.GetCurrentPlaying() == "None" && traitPlayed == false  && attachedCard.GetActive() == true)
        {
            Mirror();
            traitPlayed = true;
        }

        else if (traitPlayed == true && main.GetCurrentPlaying() == "Player1")
        {
            maxDamagePossible = 0;
            spriteRenderer.sprite = defaultMirrorMan;
            traitPlayed = false;
        }
    }


    public void Mirror()
    {
        if (attachedCard.GetAllegiance() == "Player1")
        {
            for (int i = 0; i < 5; i++)
            {
                if (player1Feild[i] != null)
                {
                    if (player1Feild[i].GetComponent<Card>().GetDamage() > maxDamagePossible)
                    {
                        maxDamagePossible = player1Feild[i].GetComponent<Card>().GetDamage();
                    }
                }
            }
        }

        else
        {
            for (int i = 0; i < 5; i++)
            {
                if (player2Feild[i] != null)
                {
                    if (player2Feild[i].GetComponent<Card>().GetDamage() > maxDamagePossible)
                    {
                        maxDamagePossible = player2Feild[i].GetComponent<Card>().GetDamage();
                    }
                }
            }
        }

        if (maxDamagePossible == 1)
        {
            spriteRenderer.sprite = d1;
        }

        else if (maxDamagePossible == 2)
        {
            spriteRenderer.sprite = d2;
        }

        else if (maxDamagePossible == 3)
        {
            spriteRenderer.sprite = d3;
        }

        else if (maxDamagePossible == 4)
        {
            spriteRenderer.sprite = d4;
        }

        else if (maxDamagePossible == 5)
        {
            spriteRenderer.sprite = d5;
        }

        else if (maxDamagePossible == 6)
        {
            spriteRenderer.sprite = d6;
        }

        else if (maxDamagePossible == 7)
        {
            spriteRenderer.sprite = d7;
        }

        else if (maxDamagePossible == 8)
        {
            spriteRenderer.sprite = d8;
        }

        else if (maxDamagePossible == 9)
        {
            spriteRenderer.sprite = d9;
        }

        else if (maxDamagePossible == 10)
        {
            spriteRenderer.sprite = d10;
        }

        else if (maxDamagePossible == 11)
        {
            spriteRenderer.sprite = d11;
        }

        else if (maxDamagePossible == 14)
        {
            spriteRenderer.sprite = d14;
        }

        else
        {
            spriteRenderer.sprite = d0;
        }
        
        attachedCard.SetDamage(maxDamagePossible);
    }
}
