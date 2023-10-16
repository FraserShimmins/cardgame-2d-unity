using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    [SerializeField] private MainMethod main;
    [SerializeField] private GameObject mainMethod;
    [SerializeField] private Card attachedCard;   

    //Sprite management
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite h1;
    

    void Update()
    {
        if (main.GetAttacking() == true)
        {
            if (attachedCard.GetHealth() == 1)
            {
                spriteRenderer.sprite = h1;
            }
        }
    }
}
