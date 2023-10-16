using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainnigDummy : MonoBehaviour
{
    [SerializeField] private MainMethod main;
    [SerializeField] private GameObject mainMethod;
    [SerializeField] private Card attachedCard;
    [SerializeField] private int defaultHealth;
    [SerializeField] private int defaultDamage;
    private int currentHealth;
    private int currentDamage;

    //Sprites
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite d1; 
    [SerializeField] private Sprite d2; 
    [SerializeField] private Sprite d3; 
    [SerializeField] private Sprite d4; 
    [SerializeField] private Sprite d5; 
    [SerializeField] private Sprite d6; 

    void Start()
    {
        currentHealth = defaultHealth;
        currentDamage = defaultDamage;
    }

    void Update()
    {
        if (main.GetAttacking() == true)
        {
            if (currentHealth != attachedCard.GetHealth())
            {
                currentDamage = currentDamage + (currentHealth - attachedCard.GetHealth());
                currentHealth = attachedCard.GetHealth();
                attachedCard.SetDamage(currentDamage);

                if (currentDamage == 1)
                {
                    spriteRenderer.sprite = d1;
                }

                else if (currentDamage == 2)
                {
                    spriteRenderer.sprite = d2;
                }

                else if (currentDamage == 3)
                {
                    spriteRenderer.sprite = d3;
                }

                else if (currentDamage == 4)
                {
                    spriteRenderer.sprite = d4;
                }

                else if (currentDamage == 5)
                {
                    spriteRenderer.sprite = d5;
                }

                else
                {
                    spriteRenderer.sprite = d6;
                }

                
            }
        }
    }
}
