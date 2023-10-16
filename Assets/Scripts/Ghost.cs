using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] private MainMethod main;
    [SerializeField] private GameObject mainMethod;
    [SerializeField] private Card attachedCard;
    [SerializeField] private GameObject reclaimedGhostPrefab;

    private Transform[] cardSlots;
    private bool[] player1AvailableCardSlots;
    private bool[] player2AvailableCardSlots;
    private List<GameObject> player1Hand;
    private List<GameObject> player2Hand;


    // Start is called before the first frame update
    void Start()
    {
        cardSlots = main.GetCardSlots();
        player1Hand = main.GetPlayer1Hand();
        player2Hand = main.GetPlayer2Hand();
        player1AvailableCardSlots = main.GetPlayer1AvailableCardSlots();
        player2AvailableCardSlots = main.GetPlayer2AvailableCardSlots();
    }

    void OnDestroy()
    {
        if (gameObject.scene.isLoaded) //Was Deleted
        {
            GameObject newCard = Instantiate(reclaimedGhostPrefab, transform.position + Vector3.right * 26, Quaternion.identity);

            if (attachedCard.GetAllegiance() == "Player1")
            {

                for (int i = 0; i < player1AvailableCardSlots.Length; i++)
                {
                    if (player1AvailableCardSlots[i] == true)
                    {

                        if (main.GetAttacking() == false)
                        {
                            newCard.transform.position = cardSlots[i].position;
                        }

                        player1AvailableCardSlots[i] = false;
                        player1Hand.Add(newCard);
                        return;
                    }
                }
            }

            else
            {
                for (int i = 0; i < player2AvailableCardSlots.Length; i++)
                {
                    if (player2AvailableCardSlots[i] == true)
                    {

                        if (main.GetAttacking() == false)
                        {
                            newCard.transform.position = cardSlots[i].position;
                        }

                        player2AvailableCardSlots[i] = false;
                        player2Hand.Add(newCard);
                        return;
                    }
                }
            }
        }
    }    
}
