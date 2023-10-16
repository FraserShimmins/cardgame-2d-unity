using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
    //Card Values
    [SerializeField] protected int health;
    [SerializeField] protected int damage;
    [SerializeField] protected bool active;
    [SerializeField] protected bool alive;
    [SerializeField] protected string description;
    [SerializeField] protected int currentFeildIndex;
    [SerializeField] protected string allegiance;


    //Info Text UI
    [SerializeField] private GameObject infoTextUI;
    private TextMeshProUGUI infoText;

    //GameManager
    [SerializeField] private MainMethod main;
    [SerializeField] private GameObject mainMethod;

    

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        infoText = infoTextUI.GetComponent<TextMeshProUGUI>();
        allegiance = null;

        //Setting the Game Manager
        main = mainMethod.GetComponent<MainMethod>(); //Gets the gameManager script attached to that object 
    }

    public void CardPlayed()
    {
        active = true;

        if (main.GetCurrentPlaying() == "Player1")
        {
            allegiance = "Player1";
        }

        else
        {
            allegiance = "Player2";
        }
    }

    public void CardDied()
    {
        alive = false;
    }

    void OnMouseEnter()
    {
        if (active == false)
        {
            transform.position += Vector3.up * 1;
            infoText.text = description;
        }
       
    }

    void OnMouseExit()
    {
        if (active == false)
        {
            transform.position -= Vector3.up * 1;
            infoText.text = "";
        }
    }

    void OnMouseDown()
    {
        
        if (main.GetSacrificing() == true && active == true)
        {
            Debug.Log("It is destroyed");
            Destroy(gameObject);
            main.Sacrifice(currentFeildIndex);
            
        }

        if (active == false)
        {
            main.SetFocus(gameObject);
            Debug.Log("New focus found");
        }
    }

    public void SetCurrentFeildIndex(int index)
    {
        currentFeildIndex = index;
    }

    public int GetCurrentFeildIndex()
    {
        return currentFeildIndex;
    }

    public bool GetActive()
    {
        return active;
    }

    public int GetDamage()
    {
        return damage;
    }

    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }

    public void TakeDamage(int incomingDamage)
    {
        health -= incomingDamage;

        if (health <= 0)
        {
            alive = false;
            
        }
    }

    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int newHealth)
    {
        health = newHealth;
    }

    public bool GetAlive()
    {
        return alive;
    }

    public string GetAllegiance()
    {
        return allegiance;
    }
}
