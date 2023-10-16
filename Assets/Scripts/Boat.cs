using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    [SerializeField] private MainMethod main;
    [SerializeField] private GameObject mainMethod;
    [SerializeField] private Card attachedCard;      

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
                SetSprite();
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
