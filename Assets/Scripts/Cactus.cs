using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    [SerializeField] private MainMethod main;
    [SerializeField] private GameObject mainMethod;
    [SerializeField] private Card attachedCard;

    private GameObject[] player1Feild;
    private GameObject[] player2Feild;

    //Sprite management
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private int defaultHealth;
    private int currentHealth;
    [SerializeField] private Sprite h4;
    [SerializeField] private Sprite h3;
    [SerializeField] private Sprite h2;
    [SerializeField] private Sprite h1;

    // Start is called before the first frame update
    void Start()
    {
        player1Feild = main.GetPlayer1Feild();
        player2Feild = main.GetPlayer2Feild();
        currentHealth = defaultHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (main.GetAttacking() == true)
        {
            if (currentHealth != attachedCard.GetHealth())
            {
                currentHealth = attachedCard.GetHealth();
                Prick();
                SetSprite();
            }
        }
    }

    public void Prick()
    {
        //Player1 attack
        if (attachedCard.GetAllegiance() == "Player1")
        {
            if (player2Feild[attachedCard.GetCurrentFeildIndex()] == null)
            {
                main.Player2TakeDamage(3);
            }

            else
            {
                if (player2Feild[attachedCard.GetCurrentFeildIndex()].GetComponent<Sheild>() != null && player2Feild[attachedCard.GetCurrentFeildIndex() - 1].GetComponent<Sheild>().GetTrait() != true) 
                {
                    player2Feild[attachedCard.GetCurrentFeildIndex()].GetComponent<Sheild>().PlayTrait();
                }

                else
                {
                    player2Feild[attachedCard.GetCurrentFeildIndex()].GetComponent<Card>().TakeDamage(3);
                }
            }
        }

        //Player 2 attack
        else
        {
            if (player1Feild[attachedCard.GetCurrentFeildIndex()] == null)
            {
                main.Player1TakeDamage(3);
            }

            else
            {
                if (player1Feild[attachedCard.GetCurrentFeildIndex()].GetComponent<Sheild>() != null && player1Feild[attachedCard.GetCurrentFeildIndex() - 1].GetComponent<Sheild>().GetTrait() != true) 
                {
                    player1Feild[attachedCard.GetCurrentFeildIndex()].GetComponent<Sheild>().PlayTrait();
                }

                else
                {
                    player1Feild[attachedCard.GetCurrentFeildIndex()].GetComponent<Card>().TakeDamage(3);
                }
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
    
    void OnDestroy()
    {
        if (gameObject.scene.isLoaded) //Was Deleted
        {
            Prick();
        }
    }
}
