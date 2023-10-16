using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jester : MonoBehaviour
{
    [SerializeField] private MainMethod main;
    [SerializeField] private GameObject mainMethod;
    [SerializeField] private Card attachedCard;
    private int currentDamage;
    private int damageDice;
    private bool traitPlayed;
    

    // Start is called before the first frame update
    void Start()
    {
        damageDice =  Random.Range(1,5);

        //Adjusting her damage accordingly
        if (damageDice == 1)
        {
            attachedCard.SetDamage(1);  
        }

        else if (damageDice == 2)
        {
            attachedCard.SetDamage(3);
        }

        else if (damageDice == 3)
        {
            attachedCard.SetDamage(5);
        }

        else
        {
            attachedCard.SetDamage(10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (traitPlayed == false && main.GetAttacking() == true  && attachedCard.GetActive() == true)
        {
            Mischief();
            traitPlayed = true;
        }

        else if (traitPlayed == true && main.GetAttacking() == false)
        {
            traitPlayed = false;
        }
    }


    public void Mischief()
    {
        damageDice =  Random.Range(1,5);

        //Adjusting her damage accordingly
        if (damageDice == 1)
        {
            attachedCard.SetDamage(1);  
        }

        else if (damageDice == 2)
        {
            attachedCard.SetDamage(3);
        }

        else if (damageDice == 3)
        {
            attachedCard.SetDamage(5);
        }

        else
        {
            attachedCard.SetDamage(10);
        }
    }
}
