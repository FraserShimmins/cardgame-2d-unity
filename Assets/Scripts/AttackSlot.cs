using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSlot : MonoBehaviour
{

    //Sprite management
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite player1Last;
    [SerializeField] private Sprite player2Last;
    

    // Start is called before the first frame update
    void Start()
    {
        player1Last = null;
        player2Last = null;
    }

    public void TurnInvisible()
    {
        spriteRenderer.enabled = false;
    }

    //Used to clean up the attack slot
    public void ErasePlayerLasts()
    {
        player1Last = null;
        player2Last = null;
    }

    //Sets the sprite that will be shown to player 1 on their turn
    public void SetPlayer1State(Sprite card)
    {
        player1Last = card;
    }

    //Sets the sprite to the last known card of the opponent on player 1's turn
    public void ShowPlayer1State()
    {
        if (player1Last != null)
        {
            spriteRenderer.sprite = player1Last;
            spriteRenderer.enabled = true;
        }  
    }

    //Sets the sprite that will be shown to player 2 on their turn
    public void SetPlayer2State(Sprite card)
    {
        player2Last = card;
    }

    //Sets the sprite to the last known card of the opponent on player 2's turn
    public void ShowPlayer2State()
    {
        if (player2Last != null)
        {
            spriteRenderer.sprite = player2Last;
            spriteRenderer.enabled = true;
        }  
    }

    
}
