using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bribe : MonoBehaviour
{
    [SerializeField] private MainMethod main;
    [SerializeField] private GameObject mainMethod;
    [SerializeField] private Card attachedCard;
    private bool traitPlayed;

    // Start is called before the first frame update
    void Start()
    {
        traitPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (traitPlayed == false && attachedCard.GetActive() == true)
        {
            Debug.Log("Bribe PLAYED");
            main.BribePlayed();
            traitPlayed = true;
        }
    }
}
