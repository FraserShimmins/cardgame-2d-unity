using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaper : MonoBehaviour
{
    [SerializeField] private MainMethod main;
    [SerializeField] private GameObject mainMethod;
    [SerializeField] private Card attachedCard;
    private bool traitPlayed;
    private int sacrificeDamage;
    
    //Health Of Card
    [SerializeField] private int defaultHealth;
    private int currentHealth;

    //Access to the board
    private GameObject[] player1Feild;
    private GameObject[] player2Feild;

    //Sprites
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite defaultReaperH3; 
    [SerializeField] private Sprite defaultReaperH2; 
    [SerializeField] private Sprite defaultReaperH1; 
    [SerializeField] private Sprite d0h3;
    [SerializeField] private Sprite d0h2;
    [SerializeField] private Sprite d0h1;
    [SerializeField] private Sprite d1h3;
    [SerializeField] private Sprite d1h2; 
    [SerializeField] private Sprite d1h1;
    [SerializeField] private Sprite d2h3; 
    [SerializeField] private Sprite d2h2; 
    [SerializeField] private Sprite d2h1; 
    [SerializeField] private Sprite d3h3; 
    [SerializeField] private Sprite d3h2; 
    [SerializeField] private Sprite d3h1; 
    [SerializeField] private Sprite d4h3; 
    [SerializeField] private Sprite d4h2; 
    [SerializeField] private Sprite d4h1; 
    [SerializeField] private Sprite d5h3; 
    [SerializeField] private Sprite d5h2; 
    [SerializeField] private Sprite d5h1; 
    [SerializeField] private Sprite d6h3; 
    [SerializeField] private Sprite d6h2; 
    [SerializeField] private Sprite d6h1; 
    [SerializeField] private Sprite d7h3; 
    [SerializeField] private Sprite d7h2; 
    [SerializeField] private Sprite d7h1; 
    [SerializeField] private Sprite d8h3; 
    [SerializeField] private Sprite d8h2; 
    [SerializeField] private Sprite d8h1; 
    [SerializeField] private Sprite d9h3; 
    [SerializeField] private Sprite d9h2; 
    [SerializeField] private Sprite d9h1; 
    [SerializeField] private Sprite d10h3; 
    [SerializeField] private Sprite d10h2; 
    [SerializeField] private Sprite d10h1; 
    [SerializeField] private Sprite d11h3;
    [SerializeField] private Sprite d11h2; 
    [SerializeField] private Sprite d11h1;
    [SerializeField] private Sprite d12h3; 
    [SerializeField] private Sprite d12h2; 
    [SerializeField] private Sprite d12h1; 
    [SerializeField] private Sprite d13h3; 
    [SerializeField] private Sprite d13h2; 
    [SerializeField] private Sprite d13h1; 
    [SerializeField] private Sprite d14h3; 
    [SerializeField] private Sprite d14h2; 
    [SerializeField] private Sprite d14h1; 
    [SerializeField] private Sprite d15h3; 
    [SerializeField] private Sprite d15h2; 
    [SerializeField] private Sprite d15h1; 


    // Start is called before the first frame update
    void Start()
    {
        player1Feild = main.GetPlayer1Feild();
        player2Feild = main.GetPlayer2Feild();
        sacrificeDamage = 0;
        currentHealth = defaultHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if ((main.GetCurrentPlaying() == "None") && (traitPlayed == false) && (attachedCard.GetActive() == true))
        {
            Reap();
            traitPlayed = true;
        }

        else if (traitPlayed == true && main.GetCurrentPlaying() == "Player1")
        {
            if (attachedCard.GetHealth() == 3)
            {
                spriteRenderer.sprite = defaultReaperH3;
            }
            
            else if (attachedCard.GetHealth() == 2)
            {
                spriteRenderer.sprite = defaultReaperH2;
            }

            else
            {
                spriteRenderer.sprite = defaultReaperH1;
            }

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


    public void Reap()
    {
        if (attachedCard.GetAllegiance() == "Player1")
        {
            sacrificeDamage = main.GetPlayer1SacrificeTokens();
        }

        else
        {
            sacrificeDamage = main.GetPlayer2SacrificeTokens();
        }

        attachedCard.SetDamage(sacrificeDamage);
        SetSprite();
    }

    private void SetSprite()
    {
        if (attachedCard.GetHealth() == 1)
        {
            if (attachedCard.GetDamage() == 0)
            {
                spriteRenderer.sprite = d0h1;
            }

            else if (attachedCard.GetDamage() == 1)
            {
                spriteRenderer.sprite = d1h1;
            }

            else if (attachedCard.GetDamage() == 2)
            {
                spriteRenderer.sprite = d2h1;
            }

            else if (attachedCard.GetDamage() == 3)
            {
                spriteRenderer.sprite = d3h1;
            }

            else if (attachedCard.GetDamage() == 4)
            {
                spriteRenderer.sprite = d4h1;
            }

            else if (attachedCard.GetDamage() == 5)
            {
                spriteRenderer.sprite = d5h1;
            }

            else if (attachedCard.GetDamage() == 6)
            {
                spriteRenderer.sprite = d6h1;
            }

            else if (attachedCard.GetDamage() == 7)
            {
                spriteRenderer.sprite = d7h1;
            }

            else if (attachedCard.GetDamage() == 8)
            {
                spriteRenderer.sprite = d8h1;
            }

            else if (attachedCard.GetDamage() == 9)
            {
                spriteRenderer.sprite = d9h1;
            }

            else if (attachedCard.GetDamage() == 10)
            {
                spriteRenderer.sprite = d10h1;
            }

            else if (attachedCard.GetDamage() == 11)
            {
                spriteRenderer.sprite = d11h1;
            }

            else if (attachedCard.GetDamage() == 12)
            {
                spriteRenderer.sprite = d12h1;
            }

            else if (attachedCard.GetDamage() == 13)
            {
                spriteRenderer.sprite = d13h1;
            }

            else if (attachedCard.GetDamage() == 14)
            {
                spriteRenderer.sprite = d14h1;
            }

            else 
            {
                spriteRenderer.sprite = d15h1;
            }

        }

        else if (attachedCard.GetHealth() == 2)
        {
            if (attachedCard.GetDamage() == 0)
            {
                spriteRenderer.sprite = d0h2;
            }

            else if (attachedCard.GetDamage() == 1)
            {
                spriteRenderer.sprite = d1h2;
            }

            else if (attachedCard.GetDamage() == 2)
            {
                spriteRenderer.sprite = d2h2;
            }

            else if (attachedCard.GetDamage() == 3)
            {
                spriteRenderer.sprite = d3h2;
            }

            else if (attachedCard.GetDamage() == 4)
            {
                spriteRenderer.sprite = d4h2;
            }

            else if (attachedCard.GetDamage() == 5)
            {
                spriteRenderer.sprite = d5h2;
            }

            else if (attachedCard.GetDamage() == 6)
            {
                spriteRenderer.sprite = d6h2;
            }

            else if (attachedCard.GetDamage() == 7)
            {
                spriteRenderer.sprite = d7h2;
            }

            else if (attachedCard.GetDamage() == 8)
            {
                spriteRenderer.sprite = d8h2;
            }

            else if (attachedCard.GetDamage() == 9)
            {
                spriteRenderer.sprite = d9h2;
            }

            else if (attachedCard.GetDamage() == 10)
            {
                spriteRenderer.sprite = d10h2;
            }

            else if (attachedCard.GetDamage() == 11)
            {
                spriteRenderer.sprite = d11h2;
            }

            else if (attachedCard.GetDamage() == 12)
            {
                spriteRenderer.sprite = d12h2;
            }

            else if (attachedCard.GetDamage() == 13)
            {
                spriteRenderer.sprite = d13h2;
            }

            else if (attachedCard.GetDamage() == 14)
            {
                spriteRenderer.sprite = d14h2;
            }

            else
            {
                spriteRenderer.sprite = d15h2;
            }

        }

        else
        {
            if (attachedCard.GetDamage() == 0)
            {
                spriteRenderer.sprite = d0h3;
            }

            else if (attachedCard.GetDamage() == 1)
            {
                spriteRenderer.sprite = d1h3;
            }

            else if (attachedCard.GetDamage() == 2)
            {
                spriteRenderer.sprite = d2h3;
            }

            else if (attachedCard.GetDamage() == 3)
            {
                spriteRenderer.sprite = d3h3;
            }

            else if (attachedCard.GetDamage() == 4)
            {
                spriteRenderer.sprite = d4h3;
            }

            else if (attachedCard.GetDamage() == 5)
            {
                spriteRenderer.sprite = d5h3;
            }

            else if (attachedCard.GetDamage() == 6)
            {
                spriteRenderer.sprite = d6h3;
            }

            else if (attachedCard.GetDamage() == 7)
            {
                spriteRenderer.sprite = d7h3;
            }

            else if (attachedCard.GetDamage() == 8)
            {
                spriteRenderer.sprite = d8h3;
            }

            else if (attachedCard.GetDamage() == 9)
            {
                spriteRenderer.sprite = d9h3;
            }

            else if (attachedCard.GetDamage() == 10)
            {
                spriteRenderer.sprite = d10h3;
            }

            else if (attachedCard.GetDamage() == 11)
            {
                spriteRenderer.sprite = d11h3;
            }

            else if (attachedCard.GetDamage() == 12)
            {
                spriteRenderer.sprite = d12h3;
            }

            else if (attachedCard.GetDamage() == 13)
            {
                spriteRenderer.sprite = d13h3;
            }

            else if (attachedCard.GetDamage() == 14)
            {
                spriteRenderer.sprite = d14h3;
            }

            else
            {
                spriteRenderer.sprite = d15h3;
            }

        }
    }
}
