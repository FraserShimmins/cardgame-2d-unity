using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheild : MonoBehaviour
{
    [SerializeField] private MainMethod main;
    [SerializeField] private GameObject mainMethod;
    [SerializeField] private Card attachedCard;
    [SerializeField] private int defaultHealth;
    private bool traitPlayed;

    //Differnt Sprites
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite sheildDown; 

    private int currentHealth;
    [SerializeField] private Sprite h8;
    [SerializeField] private Sprite h7;
    [SerializeField] private Sprite h6;
    [SerializeField] private Sprite h5;
    [SerializeField] private Sprite h4;
    [SerializeField] private Sprite h3;
    [SerializeField] private Sprite h2;
    [SerializeField] private Sprite h1;




    // Start is called before the first frame update
    void Start()
    {
        traitPlayed = false;
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

    public bool GetTrait()
    {
        return traitPlayed;
    }

    public void PlayTrait()
    {
        traitPlayed = true;
        spriteRenderer.sprite = sheildDown;
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

