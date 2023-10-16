using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class OnlineMainMethod : MonoBehaviour
{
    [SerializeField] private bool gameRunning;

    //Who's Turn is it currently
    [SerializeField] private bool player1playing;
    [SerializeField] private bool player2playing;

    //Are both players done setting up
    private bool player1ready;
    private bool player2ready;

    private int cardsDrawn;
    private bool attacking; //Are we currently in the attack phase of the game
    private bool bribeInPlay;

    //UI that will be edited
    [SerializeField] private GameObject player1healthUI;
    [SerializeField] private GameObject player2healthUI;
    [SerializeField] private GameObject heroUI;
    [SerializeField] private GameObject monsterUI;
    [SerializeField] private GameObject discardUI;
    [SerializeField] private GameObject coinUI;
    [SerializeField] private GameObject currentTurnUI;
    [SerializeField] private GameObject infoTextUI;
    [SerializeField] private GameObject sacrificeUI;
    private TextMeshProUGUI player1HealthText;
    private TextMeshProUGUI player2HealthText;
    private TextMeshProUGUI heroText;
    private TextMeshProUGUI monsterText;
    private TextMeshProUGUI discardText;
    private TextMeshProUGUI coinText;
    private TextMeshProUGUI infoText;
    private TextMeshProUGUI turnText;
    private TextMeshProUGUI sacrificeText;
    
    [SerializeField] private SpriteRenderer gameBoardSprite;

    //The transforms of the handslots
    [SerializeField] private Transform[] cardSlots;
    [SerializeField] private CardSlot[] cardSlotsObjects;
    [SerializeField] private bool[] player1AvailableCardSlots;
    [SerializeField] private bool[] player2AvailableCardSlots;
    [SerializeField] private Transform player1DeloadSlot;
    [SerializeField] private Transform player2DeloadSlot;

    [SerializeField] private List<GameObject> player1Hand = new List<GameObject>();
    [SerializeField] private List<GameObject> player2Hand = new List<GameObject>();

    //The Arrays of the game Board
    [SerializeField] private GameObject[] player1Feild;
    [SerializeField] private GameObject[] player2Feild;
    [SerializeField] private Transform[] lowerFeildSlots;
    [SerializeField] private Transform[] higherFeildSlots;

    //Card we are currently dealing with
    [SerializeField] private GameObject focus;
    [SerializeField] private bool focused;
    
    //Variables about Sacrifce mechanic
    [SerializeField] private bool sacrificing;

    //Values used for playing a card
    [SerializeField] private GameObject slot;
    private int index;

    //Mouse Textures
    [SerializeField] private Texture2D defultTexture;
    [SerializeField] private Texture2D focusedTexture;
    [SerializeField] private Texture2D sacrificeTexture;
    private bool defaultCursor;

    //Prefabs of all cards that can be drawn
    [SerializeField] private GameObject sheildHeroPrefab;
    [SerializeField] private GameObject recruitHeroPrefab;
    [SerializeField] private GameObject brawlerHeroPrefab;
    [SerializeField] private GameObject offeringHeroPrefab;
    [SerializeField] private GameObject superOfferingHeroPrefab;
    [SerializeField] private GameObject tridentHeroPrefab;
    [SerializeField] private GameObject fortressHeroPrefab;
    [SerializeField] private GameObject trojanHorseHeroPrefab;
    [SerializeField] private GameObject boatHeroPrefab;
    [SerializeField] private GameObject bowHeroPrefab;
    [SerializeField] private GameObject windSpellHeroPrefab;
    [SerializeField] private GameObject bribeHeroPrefab;
    [SerializeField] private GameObject merenaryHeroPrefab;
    [SerializeField] private GameObject wizardApprenticeHeroPrefab;
    [SerializeField] private GameObject dogHeroPrefab;
    [SerializeField] private GameObject javelinHeroPrefab;
    [SerializeField] private GameObject clubHeroPrefab;
    [SerializeField] private GameObject trainingDummyHeroPrefab;
    [SerializeField] private GameObject cactusHeroPrefab;
    [SerializeField] private GameObject snakeHorrorPrefab;
    [SerializeField] private GameObject sacrificialSkullHorrorPrefab;
    [SerializeField] private GameObject hauntedScarecrowHorrorPrefab;
    [SerializeField] private GameObject mimicHorrorPrefab;
    [SerializeField] private GameObject holeHorrorPrefab;
    [SerializeField] private GameObject handHorrorPrefab;
    [SerializeField] private GameObject spiderHorrorPrefab;
    [SerializeField] private GameObject hydraHorrorPrefab;
    [SerializeField] private GameObject eyeHorrorPrefab;
    [SerializeField] private GameObject coffinHorrorPrefab;
    [SerializeField] private GameObject tombStoneHorrorPrefab;
    [SerializeField] private GameObject reaperHorrorPrefab;
    [SerializeField] private GameObject krackenHorrorPrefab;
    [SerializeField] private GameObject ghostHorrorPrefab;
    [SerializeField] private GameObject jesterHorrorPrefab;
    [SerializeField] private GameObject vileOfBloodHorrorPrefab;
    [SerializeField] private GameObject minotaurHorrorPrefab;
    [SerializeField] private GameObject mirrorManHorrorPrefab;
    [SerializeField] private GameObject slimeHorrorPrefab;
    [SerializeField] private GameObject cultistHorrorPrefab;
    [SerializeField] private GameObject possesedRecruitHorrorPrefab;
    [SerializeField] private GameObject worldSnakeHorrorPrefab;
    [SerializeField] private GameObject eggHorrorPrefab;



    //Setting up the decks of cards for both players
    [SerializeField] private List<GameObject> heroDeck1 = new List<GameObject>();
    [SerializeField] private List<GameObject> heroDeck2 = new List<GameObject>();
    [SerializeField] private List<GameObject> monsterDeck1 = new List<GameObject>();
    [SerializeField] private List<GameObject> monsterDeck2 = new List<GameObject>();


    //Random Number that will be used for building decks
    private int prob;
    private int prob2;
    private int choosingCardProb;

    //Player1 Values
    [SerializeField] private int player1Health;
    [SerializeField] private int player1Coins;
    [SerializeField] private int player1MonsterLeft;
    [SerializeField] private int player1HeroLeft;
    [SerializeField] private int player1DiscardSize;
    [SerializeField] private int player1SacrificeTokens;
    private int player1Attack;
    private bool player1FeildOpen;
    private Card player1AttackingCard;

    //Player2 Values
    [SerializeField] private int player2Health;
    [SerializeField] private int player2Coins;
    [SerializeField] private int player2MonsterLeft;
    [SerializeField] private int player2HeroLeft;
    [SerializeField] private int player2DiscardSize;
    [SerializeField] private int player2SacrificeTokens;
    private int player2Attack;
    private bool player2FeildOpen;
    private Card player2AttackingCard;

    //New Turn Values
    [SerializeField] private int turnTotal;
    [SerializeField] private int coinsGained;
    private Card postAttackCard;



//---------------------------------------------------------------------------------------------------------------------------------------------------------------
    void Start()
    {
        gameRunning = true;
        //Setting up the turn order
        player1playing = true;
        player2playing = false;
        attacking = false;
        turnTotal = 1;

        //Setting up the UI
        player1HealthText = player1healthUI.GetComponent<TextMeshProUGUI>();
        player2HealthText = player2healthUI.GetComponent<TextMeshProUGUI>();
        heroText = heroUI.GetComponent<TextMeshProUGUI>();
        monsterText = monsterUI.GetComponent<TextMeshProUGUI>();
        discardText = discardUI.GetComponent<TextMeshProUGUI>();
        coinText = coinUI.GetComponent<TextMeshProUGUI>();
        infoText = infoTextUI.GetComponent<TextMeshProUGUI>();
        turnText = currentTurnUI.GetComponent<TextMeshProUGUI>();
        sacrificeText = sacrificeUI.GetComponent<TextMeshProUGUI>();
        monsterText.text = "35";
        heroText.text = "35";


        //Setting up Player Start Values

        //Player 1
        player1Health = 100;
        player1Coins = 0;
        player1MonsterLeft = 35;
        player1HeroLeft = 35;
        player1ready = false;
        
        //Player 2
        player2Health = 100;
        player2Coins = 0;
        player2MonsterLeft = 35;
        player2HeroLeft = 35;
        player2ready = false;

        bribeInPlay = false;

        //Setting up focus values
        focus = null;
        focused = false;
        defaultCursor = true;
        sacrificing = false;
        cardsDrawn = 0;

        //Inital Coin Gain
        coinsGained = Random.Range(3,6);
        player1Coins += coinsGained;
        player2Coins += coinsGained;
        coinText.text = player1Coins.ToString();

        //Setting up Decks for player 1

        //Setting up Monster Deck
        for (int i = 0; i < 35; i++) 
        {
            prob = Random.Range(1,101);

            if (prob <= 40)  //40%
            {
                //Blood Card Added
                choosingCardProb = Random.Range(1,10);

                if (choosingCardProb == 1)  
                {
                    GameObject newPrefabInstance = Instantiate(holeHorrorPrefab, transform.position + Vector3.right * 10, Quaternion.identity);
                    monsterDeck1.Add(newPrefabInstance);
                }

                else if (choosingCardProb == 2)
                {
                    GameObject newPrefabInstance = Instantiate(handHorrorPrefab, transform.position + Vector3.right * 10, Quaternion.identity);
                    monsterDeck1.Add(newPrefabInstance);
                }

                 else if (choosingCardProb == 3)
                {
                    GameObject newPrefabInstance = Instantiate(coffinHorrorPrefab, transform.position + Vector3.right * 10, Quaternion.identity);
                    monsterDeck1.Add(newPrefabInstance);
                }

                 else if (choosingCardProb == 4)
                {
                    GameObject newPrefabInstance = Instantiate(tombStoneHorrorPrefab, transform.position + Vector3.right * 10, Quaternion.identity);
                    monsterDeck1.Add(newPrefabInstance);
                }

                 else if (choosingCardProb == 5)
                {
                    GameObject newPrefabInstance = Instantiate(jesterHorrorPrefab, transform.position + Vector3.right * 10, Quaternion.identity);
                    monsterDeck1.Add(newPrefabInstance);
                }

                else if (choosingCardProb == 6)
                {
                    GameObject newPrefabInstance = Instantiate(vileOfBloodHorrorPrefab, transform.position + Vector3.right * 10, Quaternion.identity);
                    monsterDeck1.Add(newPrefabInstance);
                }

                else if (choosingCardProb == 7)
                {
                    GameObject newPrefabInstance = Instantiate(mirrorManHorrorPrefab, transform.position + Vector3.right * 10, Quaternion.identity);
                    monsterDeck1.Add(newPrefabInstance);
                }

                else if (choosingCardProb == 8)
                {
                    GameObject newPrefabInstance = Instantiate(slimeHorrorPrefab, transform.position + Vector3.right * 10, Quaternion.identity);
                    monsterDeck1.Add(newPrefabInstance);
                }

                else
                {
                    GameObject newPrefabInstance = Instantiate(cultistHorrorPrefab, transform.position + Vector3.right * 10, Quaternion.identity);
                    monsterDeck1.Add(newPrefabInstance);
                }
            }

            else
            {
                prob2 = Random.Range(1,101);

                if (prob2 <= 45) //45%
                {
                    //1 Sacrfice Card Added
                    choosingCardProb = Random.Range(1,7);

                    if (choosingCardProb == 1)  
                    {
                        GameObject newPrefabInstance = Instantiate(eyeHorrorPrefab, transform.position + Vector3.right * 11, Quaternion.identity);
                        monsterDeck1.Add(newPrefabInstance);
                    }

                    else if (choosingCardProb == 2)
                    {
                        GameObject newPrefabInstance = Instantiate(ghostHorrorPrefab, transform.position + Vector3.right * 11, Quaternion.identity);
                        monsterDeck1.Add(newPrefabInstance);
                    }

                    else if (choosingCardProb == 3)
                    {
                        GameObject newPrefabInstance = Instantiate(krackenHorrorPrefab, transform.position + Vector3.right * 11, Quaternion.identity);
                        monsterDeck1.Add(newPrefabInstance);
                    }

                    else if (choosingCardProb == 4)
                    {
                        GameObject newPrefabInstance = Instantiate(mimicHorrorPrefab, transform.position + Vector3.right * 11, Quaternion.identity);
                        monsterDeck1.Add(newPrefabInstance);
                    }

                    else if (choosingCardProb == 5)
                    {
                        GameObject newPrefabInstance = Instantiate(sacrificialSkullHorrorPrefab, transform.position + Vector3.right * 11, Quaternion.identity);
                        monsterDeck1.Add(newPrefabInstance);
                    }

                    else
                    {
                        GameObject newPrefabInstance = Instantiate(spiderHorrorPrefab, transform.position + Vector3.right * 11, Quaternion.identity);
                        monsterDeck1.Add(newPrefabInstance);
                    }
                }

                else if (prob2 <= 75) //30%
                {
                    //2 Sacrifice Card Added
                    choosingCardProb = Random.Range(1,5);

                    if (choosingCardProb == 1)  
                    {
                        GameObject newPrefabInstance = Instantiate(snakeHorrorPrefab, transform.position + Vector3.right * 12, Quaternion.identity);
                        monsterDeck1.Add(newPrefabInstance);
                    }

                    else if (choosingCardProb == 2)
                    {
                        GameObject newPrefabInstance = Instantiate(reaperHorrorPrefab, transform.position + Vector3.right * 12, Quaternion.identity);
                        monsterDeck1.Add(newPrefabInstance);
                    }

                    else if (choosingCardProb == 3)
                    {
                        GameObject newPrefabInstance = Instantiate(minotaurHorrorPrefab, transform.position + Vector3.right * 12, Quaternion.identity);
                        monsterDeck1.Add(newPrefabInstance);
                    }

                    else
                    {
                        GameObject newPrefabInstance = Instantiate(possesedRecruitHorrorPrefab, transform.position + Vector3.right * 12, Quaternion.identity);
                        monsterDeck1.Add(newPrefabInstance);
                    }


                }

                else  //25%
                {
                    //3 Sacrifice Card Added
                    choosingCardProb = Random.Range(1,5);

                    if (choosingCardProb == 1)  
                    {
                        GameObject newPrefabInstance = Instantiate(hauntedScarecrowHorrorPrefab, transform.position + Vector3.right * 13, Quaternion.identity);
                        monsterDeck1.Add(newPrefabInstance);
                    }

                    else if (choosingCardProb == 2)
                    {
                        GameObject newPrefabInstance = Instantiate(hydraHorrorPrefab, transform.position + Vector3.right * 13, Quaternion.identity);
                        monsterDeck1.Add(newPrefabInstance);
                    }

                    else if (choosingCardProb == 3)
                    {
                        GameObject newPrefabInstance = Instantiate(worldSnakeHorrorPrefab, transform.position + Vector3.right * 13, Quaternion.identity);
                        monsterDeck1.Add(newPrefabInstance);
                    }

                    else
                    {
                        GameObject newPrefabInstance = Instantiate(eggHorrorPrefab, transform.position + Vector3.right * 13, Quaternion.identity);
                        monsterDeck1.Add(newPrefabInstance);
                    }
                }
                
            }
        }

        //Setting up Hero Deck
        for (int i = 0; i < 35; i++) 
        {
            prob = Random.Range(1,101);

            if (prob <= 50) //50%
            {
                choosingCardProb = Random.Range(1,8);
                
                if (choosingCardProb == 1)  
                {
                    GameObject newPrefabInstance = Instantiate(bribeHeroPrefab, transform.position + Vector3.right * 14, Quaternion.identity);
                    heroDeck1.Add(newPrefabInstance);
                }

                else if (choosingCardProb == 2)
                {
                    GameObject newPrefabInstance = Instantiate(windSpellHeroPrefab, transform.position + Vector3.right * 14, Quaternion.identity);
                    heroDeck1.Add(newPrefabInstance);
                }

                 else if (choosingCardProb == 3)
                {
                    GameObject newPrefabInstance = Instantiate(offeringHeroPrefab, transform.position + Vector3.right * 14, Quaternion.identity);
                    heroDeck1.Add(newPrefabInstance);
                }

                 else if (choosingCardProb == 4)
                {
                    GameObject newPrefabInstance = Instantiate(superOfferingHeroPrefab, transform.position + Vector3.right * 14, Quaternion.identity);
                    heroDeck1.Add(newPrefabInstance);
                }

                 else if (choosingCardProb == 5)
                {
                    GameObject newPrefabInstance = Instantiate(trojanHorseHeroPrefab, transform.position + Vector3.right * 14, Quaternion.identity);
                    heroDeck1.Add(newPrefabInstance);
                }

                else if (choosingCardProb == 6)
                {
                    GameObject newPrefabInstance = Instantiate(wizardApprenticeHeroPrefab, transform.position + Vector3.right * 14, Quaternion.identity);
                    heroDeck1.Add(newPrefabInstance);
                }

                else
                {
                    GameObject newPrefabInstance = Instantiate(recruitHeroPrefab, transform.position + Vector3.right * 14, Quaternion.identity);
                    heroDeck1.Add(newPrefabInstance);
                }
            }

            else if (prob <= 80) //30%
            {
                //6 Gold Card Added
                choosingCardProb = Random.Range(1,8);
                
                if (choosingCardProb == 1)  
                {
                    GameObject newPrefabInstance = Instantiate(boatHeroPrefab, transform.position + Vector3.right * 15, Quaternion.identity);
                    heroDeck1.Add(newPrefabInstance);
                }

                else if (choosingCardProb == 2)
                {
                    GameObject newPrefabInstance = Instantiate(brawlerHeroPrefab, transform.position + Vector3.right * 15, Quaternion.identity);
                    heroDeck1.Add(newPrefabInstance);
                }

                else if (choosingCardProb == 3)
                {
                    GameObject newPrefabInstance = Instantiate(tridentHeroPrefab, transform.position + Vector3.right * 15, Quaternion.identity);
                    heroDeck1.Add(newPrefabInstance);
                }

                else if (choosingCardProb == 4)
                {
                    GameObject newPrefabInstance = Instantiate(dogHeroPrefab, transform.position + Vector3.right * 15, Quaternion.identity);
                    heroDeck1.Add(newPrefabInstance);
                }

                else if (choosingCardProb == 5)
                {
                    GameObject newPrefabInstance = Instantiate(javelinHeroPrefab, transform.position + Vector3.right * 15, Quaternion.identity);
                    heroDeck1.Add(newPrefabInstance);
                }

                else if (choosingCardProb == 6)
                {
                    GameObject newPrefabInstance = Instantiate(clubHeroPrefab, transform.position + Vector3.right * 15, Quaternion.identity);
                    heroDeck1.Add(newPrefabInstance);
                }

                else
                {
                    GameObject newPrefabInstance = Instantiate(trainingDummyHeroPrefab, transform.position + Vector3.right * 15, Quaternion.identity);
                    heroDeck1.Add(newPrefabInstance);
                }


            }

            else  //20%
            {
                //9 Gold Card Added
                choosingCardProb = Random.Range(1,6);
                
                if (choosingCardProb == 1)  
                {
                    GameObject newPrefabInstance = Instantiate(sheildHeroPrefab, transform.position + Vector3.right * 16, Quaternion.identity);
                    heroDeck1.Add(newPrefabInstance);
                }

                else if (choosingCardProb == 2)
                {
                    GameObject newPrefabInstance = Instantiate(fortressHeroPrefab, transform.position + Vector3.right * 16, Quaternion.identity);
                    heroDeck1.Add(newPrefabInstance);
                }

                else if (choosingCardProb == 3)
                {
                    GameObject newPrefabInstance = Instantiate(bowHeroPrefab, transform.position + Vector3.right * 16, Quaternion.identity);
                    heroDeck1.Add(newPrefabInstance);
                }

                else if (choosingCardProb == 4)
                {
                    GameObject newPrefabInstance = Instantiate(merenaryHeroPrefab, transform.position + Vector3.right * 16, Quaternion.identity);
                    heroDeck1.Add(newPrefabInstance);
                }

                else
                {
                    GameObject newPrefabInstance = Instantiate(cactusHeroPrefab, transform.position + Vector3.right * 16, Quaternion.identity);
                    heroDeck1.Add(newPrefabInstance);
                }
            }
        }
      
        //Setting up Decks for player 2

        //Setting up Monster Deck
        for (int i = 0; i < 35; i++) 
        {
            prob = Random.Range(1,101);

            if (prob <= 40)  //40%
            {
                //Blood Card Added
                choosingCardProb = Random.Range(1,10);

                if (choosingCardProb == 1)  
                {
                    GameObject newPrefabInstance = Instantiate(holeHorrorPrefab, transform.position + Vector3.right * 20, Quaternion.identity);
                    monsterDeck2.Add(newPrefabInstance);
                }

                else if (choosingCardProb == 2)
                {
                    GameObject newPrefabInstance = Instantiate(handHorrorPrefab, transform.position + Vector3.right * 20, Quaternion.identity);
                    monsterDeck2.Add(newPrefabInstance);
                }

                 else if (choosingCardProb == 3)
                {
                    GameObject newPrefabInstance = Instantiate(coffinHorrorPrefab, transform.position + Vector3.right * 20, Quaternion.identity);
                    monsterDeck2.Add(newPrefabInstance);
                }

                 else if (choosingCardProb == 4)
                {
                    GameObject newPrefabInstance = Instantiate(tombStoneHorrorPrefab, transform.position + Vector3.right * 20, Quaternion.identity);
                    monsterDeck2.Add(newPrefabInstance);
                }

                 else if (choosingCardProb == 5)
                {
                    GameObject newPrefabInstance = Instantiate(jesterHorrorPrefab, transform.position + Vector3.right * 20, Quaternion.identity);
                    monsterDeck2.Add(newPrefabInstance);
                }

                else if (choosingCardProb == 6)
                {
                    GameObject newPrefabInstance = Instantiate(vileOfBloodHorrorPrefab, transform.position + Vector3.right * 10, Quaternion.identity);
                    monsterDeck2.Add(newPrefabInstance);
                }

                else if (choosingCardProb == 7)
                {
                    GameObject newPrefabInstance = Instantiate(mirrorManHorrorPrefab, transform.position + Vector3.right * 10, Quaternion.identity);
                    monsterDeck2.Add(newPrefabInstance);
                }

                else if (choosingCardProb == 8)
                {
                    GameObject newPrefabInstance = Instantiate(slimeHorrorPrefab, transform.position + Vector3.right * 10, Quaternion.identity);
                    monsterDeck2.Add(newPrefabInstance);
                }

                else
                {
                    GameObject newPrefabInstance = Instantiate(cultistHorrorPrefab, transform.position + Vector3.right * 10, Quaternion.identity);
                    monsterDeck2.Add(newPrefabInstance);
                }
            }

            else
            {
                prob2 = Random.Range(1,101);

                if (prob2 <= 45) //45%
                {
                    choosingCardProb = Random.Range(1,7);

                    if (choosingCardProb == 1)  
                    {
                        GameObject newPrefabInstance = Instantiate(eyeHorrorPrefab, transform.position + Vector3.right * 21, Quaternion.identity);
                        monsterDeck2.Add(newPrefabInstance);
                    }

                    else if (choosingCardProb == 2)
                    {
                        GameObject newPrefabInstance = Instantiate(ghostHorrorPrefab, transform.position + Vector3.right * 21, Quaternion.identity);
                        monsterDeck2.Add(newPrefabInstance);
                    }

                    else if (choosingCardProb == 3)
                    {
                        GameObject newPrefabInstance = Instantiate(krackenHorrorPrefab, transform.position + Vector3.right * 21, Quaternion.identity);
                        monsterDeck2.Add(newPrefabInstance);
                    }

                    else if (choosingCardProb == 4)
                    {
                        GameObject newPrefabInstance = Instantiate(mimicHorrorPrefab, transform.position + Vector3.right * 21, Quaternion.identity);
                        monsterDeck2.Add(newPrefabInstance);
                    }

                    else if (choosingCardProb == 5)
                    {
                        GameObject newPrefabInstance = Instantiate(sacrificialSkullHorrorPrefab, transform.position + Vector3.right * 21, Quaternion.identity);
                        monsterDeck2.Add(newPrefabInstance);
                    }

                    else
                    {
                        GameObject newPrefabInstance = Instantiate(spiderHorrorPrefab, transform.position + Vector3.right * 21, Quaternion.identity);
                        monsterDeck2.Add(newPrefabInstance);
                    }
                }

                else if (prob2 <= 75) //30%
                {
                    //2 Sacrifice Card Added
                    choosingCardProb = Random.Range(1,5);

                    if (choosingCardProb == 1)  
                    {
                        GameObject newPrefabInstance = Instantiate(snakeHorrorPrefab, transform.position + Vector3.right * 22, Quaternion.identity);
                        monsterDeck2.Add(newPrefabInstance);
                    }

                    else if (choosingCardProb == 2)
                    {
                        GameObject newPrefabInstance = Instantiate(reaperHorrorPrefab, transform.position + Vector3.right * 22, Quaternion.identity);
                        monsterDeck2.Add(newPrefabInstance);
                    }

                    else if (choosingCardProb == 3)
                    {
                        GameObject newPrefabInstance = Instantiate(minotaurHorrorPrefab, transform.position + Vector3.right * 22, Quaternion.identity);
                        monsterDeck2.Add(newPrefabInstance);
                    }

                    else
                    {
                        GameObject newPrefabInstance = Instantiate(possesedRecruitHorrorPrefab, transform.position + Vector3.right * 12, Quaternion.identity);
                        monsterDeck2.Add(newPrefabInstance);
                    }

                }

                else  //25%
                {
                    //3 Sacrifice Card Added
                    choosingCardProb = Random.Range(1,5);

                    if (choosingCardProb == 1)  
                    {
                        GameObject newPrefabInstance = Instantiate(hauntedScarecrowHorrorPrefab, transform.position + Vector3.right * 23, Quaternion.identity);
                        monsterDeck2.Add(newPrefabInstance);
                    }

                    else if (choosingCardProb == 2)
                    {
                        GameObject newPrefabInstance = Instantiate(hydraHorrorPrefab, transform.position + Vector3.right * 23, Quaternion.identity);
                        monsterDeck2.Add(newPrefabInstance);
                    }

                    else if (choosingCardProb == 3)
                    {
                        GameObject newPrefabInstance = Instantiate(worldSnakeHorrorPrefab, transform.position + Vector3.right * 23, Quaternion.identity);
                        monsterDeck2.Add(newPrefabInstance);
                    }

                    else
                    {
                        GameObject newPrefabInstance = Instantiate(eggHorrorPrefab, transform.position + Vector3.right * 23, Quaternion.identity);
                        monsterDeck2.Add(newPrefabInstance);
                    }
                }
                
            }
        }

        //Setting up Hero Deck
        for (int i = 0; i < 35; i++) 
        {
            prob = Random.Range(1,101);

            if (prob <= 50) //50%
            {
                choosingCardProb = Random.Range(1,8);
                
                if (choosingCardProb == 1)  
                {
                    GameObject newPrefabInstance = Instantiate(bribeHeroPrefab, transform.position + Vector3.right * 24, Quaternion.identity);
                    heroDeck2.Add(newPrefabInstance);
                }

                else if (choosingCardProb == 2)
                {
                    GameObject newPrefabInstance = Instantiate(windSpellHeroPrefab, transform.position + Vector3.right * 24, Quaternion.identity);
                    heroDeck2.Add(newPrefabInstance);
                }

                 else if (choosingCardProb == 3)
                {
                    GameObject newPrefabInstance = Instantiate(offeringHeroPrefab, transform.position + Vector3.right * 24, Quaternion.identity);
                    heroDeck2.Add(newPrefabInstance);
                }

                 else if (choosingCardProb == 4)
                {
                    GameObject newPrefabInstance = Instantiate(superOfferingHeroPrefab, transform.position + Vector3.right * 24, Quaternion.identity);
                    heroDeck2.Add(newPrefabInstance);
                }

                 else if (choosingCardProb == 5)
                {
                    GameObject newPrefabInstance = Instantiate(trojanHorseHeroPrefab, transform.position + Vector3.right * 24, Quaternion.identity);
                    heroDeck2.Add(newPrefabInstance);
                }

                else if (choosingCardProb == 6)
                {
                    GameObject newPrefabInstance = Instantiate(wizardApprenticeHeroPrefab, transform.position + Vector3.right * 24, Quaternion.identity);
                    heroDeck2.Add(newPrefabInstance);
                }

                else
                {
                    GameObject newPrefabInstance = Instantiate(recruitHeroPrefab, transform.position + Vector3.right * 24, Quaternion.identity);
                    heroDeck2.Add(newPrefabInstance);
                }
            }

            else if (prob <= 80) //30%
            {
                //6 Gold Card Added
                choosingCardProb = Random.Range(1,8);
                
                if (choosingCardProb == 1)  
                {
                    GameObject newPrefabInstance = Instantiate(boatHeroPrefab, transform.position + Vector3.right * 25, Quaternion.identity);
                    heroDeck2.Add(newPrefabInstance);
                }

                else if (choosingCardProb == 2)
                {
                    GameObject newPrefabInstance = Instantiate(brawlerHeroPrefab, transform.position + Vector3.right * 25, Quaternion.identity);
                    heroDeck2.Add(newPrefabInstance);
                }

                else if (choosingCardProb == 3)
                {
                    GameObject newPrefabInstance = Instantiate(tridentHeroPrefab, transform.position + Vector3.right * 25, Quaternion.identity);
                    heroDeck2.Add(newPrefabInstance);
                }

                else if (choosingCardProb == 4)
                {
                    GameObject newPrefabInstance = Instantiate(dogHeroPrefab, transform.position + Vector3.right * 25, Quaternion.identity);
                    heroDeck2.Add(newPrefabInstance);
                }

                else if (choosingCardProb == 5)
                {
                    GameObject newPrefabInstance = Instantiate(javelinHeroPrefab, transform.position + Vector3.right * 25, Quaternion.identity);
                    heroDeck2.Add(newPrefabInstance);
                }

                else if (choosingCardProb == 6)
                {
                    GameObject newPrefabInstance = Instantiate(clubHeroPrefab, transform.position + Vector3.right * 25, Quaternion.identity);
                    heroDeck2.Add(newPrefabInstance);
                }

                else
                {
                    GameObject newPrefabInstance = Instantiate(trainingDummyHeroPrefab, transform.position + Vector3.right * 25, Quaternion.identity);
                    heroDeck2.Add(newPrefabInstance);
                }
            }

            else  //20%
            {
                //9 Gold Card Added
                choosingCardProb = Random.Range(1,6);
                
                if (choosingCardProb == 1)  
                {
                    GameObject newPrefabInstance = Instantiate(sheildHeroPrefab, transform.position + Vector3.right * 26, Quaternion.identity);
                    heroDeck2.Add(newPrefabInstance);
                }

                else if (choosingCardProb == 2)
                {
                    GameObject newPrefabInstance = Instantiate(fortressHeroPrefab, transform.position + Vector3.right * 26, Quaternion.identity);
                    heroDeck2.Add(newPrefabInstance);
                }

                else if (choosingCardProb == 3)
                {
                    GameObject newPrefabInstance = Instantiate(bowHeroPrefab, transform.position + Vector3.right * 26, Quaternion.identity);
                    heroDeck2.Add(newPrefabInstance);
                }

                else if (choosingCardProb == 4)
                {
                    GameObject newPrefabInstance = Instantiate(merenaryHeroPrefab, transform.position + Vector3.right * 26, Quaternion.identity);
                    heroDeck2.Add(newPrefabInstance);
                }

                else
                {
                    GameObject newPrefabInstance = Instantiate(cactusHeroPrefab, transform.position + Vector3.right * 26, Quaternion.identity);
                    heroDeck2.Add(newPrefabInstance);
                }
            }
        }

        infoText.text = "ROUND: " + turnTotal.ToString() + "                      " + "COINS GAINED: " + coinsGained.ToString() + "                      " + "- [PLAYER 1 TO PLAY] -";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameExit();
        }

        if (Input.GetMouseButton(1)) //right mouse click
        {
            Defocus();
        }

        if (focused == true && (defaultCursor == true || sacrificing == true))
        {
            sacrificing = false;
            Cursor.SetCursor(focusedTexture, Vector2.zero, CursorMode.Auto);
        }

        if (player1Health <= 0 && player2Health <= 0)
        {
            Debug.Log("Draw");
        }

        else if (player1Health <= 0)
        {
            Debug.Log("Player 2 Wins");
        }

        else if (player2Health <= 0)
        {
            Debug.Log("Player 1 Wins");
        }
    }

    public void ReadyUp()
    {
        bribeInPlay = false;
        Defocus();

        if (player1playing == true)
        {
            player1playing = false;
            player2playing = true;
            DeloadPlayer1();
            LoadPlayer2();
        }

        else if (player2playing == true)
        {
            player2playing = false;
            DeloadPlayer2();
            AttackPhase();
        }

        //Both players are loaded & ready to attack
        else if (attacking == true)
        {
            player1playing = true;
            DeloadAll(); //Empty cards after attack phase
            NewTurn(); //Begin a new turn
        }


        else if (player1playing == false && player2playing == false)
        {
            //Attack!!!
            Attack();
        }
    }

    public void AttackPhase()
    {
        //Reload player 1 in the lower feild on the board
        for (int i = 0; i < player1Feild.Length; i++)
        {
            if (player1Feild[i] != null)
            {
                player1Feild[i].transform.position = lowerFeildSlots[i].position;
            }
        }

        //Reload player 2 in the upper feild on the board
        for (int i = 0; i < player2Feild.Length; i++)
        {
            if (player2Feild[i] != null)
            {
                player2Feild[i].transform.position = higherFeildSlots[i].position;
            }
        }
        
        sacrificeText.text = "-";
        discardText.text = "-";
        monsterText.text = "-";
        heroText.text = "-";
        coinText.text = "-";

        infoText.text = "[BOTH PLAYERS LOADED]                    " + "Press 'End Turn' to begin attack phase";
    }

    public void NewTurn()
    {
        attacking = false;
        turnTotal += 1;
        turnText.text = turnTotal.ToString();

        if (turnTotal < 5)
        {
            coinsGained = Random.Range(3,6);
        }

        else if (turnTotal < 10)
        {
            coinsGained = Random.Range(5,8);
        }

        else
        {
            coinsGained = Random.Range(7,10);
        }

        player1Coins += coinsGained;
        player2Coins += coinsGained;
        LoadPlayer1();

    }

    public void Attack()
    {
        player1Attack = 0;
        player2Attack = 0;
        attacking = true;
        
        //Move through the lanes & cause the cards to attack eachother
        for (int i = 0; i < 5; i++)
        {
            //If nothing is in player 1's Slot
            if (player1Feild[i] == null)
            {
                player1Attack = 0;
                player1AttackingCard = null;
            }

            else
            {
                player1AttackingCard = player1Feild[i].GetComponent<Card>();
                player1Attack = player1AttackingCard.GetDamage();

                if (player1AttackingCard.GetComponent<Hydra>() != null)
                {
                    player1AttackingCard.GetComponent<Hydra>().Blast();
                }
            }

            //If nothing is in player 2's Slot
            if (player2Feild[i] == null)
            {
                player2Attack = 0;
                player2AttackingCard = null;
            }

            else
            {
                player2AttackingCard = player2Feild[i].GetComponent<Card>();
                player2Attack = player2AttackingCard.GetDamage();

                if (player2AttackingCard.GetComponent<Hydra>() != null)
                {
                    player2AttackingCard.GetComponent<Hydra>().Blast();
                }
            }

            //Does the enemy deal damage to the opponent directly
            if (player2AttackingCard == null && player1AttackingCard != null) //Player 2 is attacked
            {
                player2Health = player2Health - player1Attack;
                player2HealthText.text = player2Health.ToString();

                //Heal player 1 the damage if delt by eye horror
                if (player1AttackingCard.GetComponent<Eye>() != null)
                {
                    player1Health = player1Health + player1Attack;
                    player1HealthText.text = player1Health.ToString();
                }
            }

            else if (player1AttackingCard == null && player2AttackingCard != null) //Player 1 is attacked
            {
                player1Health = player1Health - player2Attack;
                player1HealthText.text = player1Health.ToString();

                //Heal player 2 the damage if delt by eye horror
                if (player2AttackingCard.GetComponent<Eye>() != null)
                {
                    player2Health = player2Health + player2Attack;
                    player2HealthText.text = player2Health.ToString();
                }
            }

            else if (player1AttackingCard != null && player2AttackingCard != null) //Player 1 & 2 attack eachother 
            {
                //Player 1 Card attacked is an active sheild hero
                if (player1AttackingCard.GetComponent<Sheild>() != null && player1AttackingCard.GetComponent<Sheild>().GetTrait() != true && player2AttackingCard.GetDamage() != 0) 
                {
                    player1AttackingCard.GetComponent<Sheild>().PlayTrait();
                }

                //player 2 Card Attacking is an archer
                else if (player2AttackingCard.GetComponent<Bow>() != null)
                {
                    player1Health = player1Health - player2Attack;
                    player1HealthText.text = player1Health.ToString();
                }   

                else
                {
                    player1AttackingCard.TakeDamage(player2Attack);  //Player 1's card takes damage
                }

                //Player 2 Card attacked is an active sheild hero
                if (player2AttackingCard.GetComponent<Sheild>() != null && player2AttackingCard.GetComponent<Sheild>().GetTrait() != true && player1AttackingCard.GetDamage() != 0)
                {
                    player2AttackingCard.GetComponent<Sheild>().PlayTrait();
                }

                //player 1 Card Attacking is an archer
                else if (player1AttackingCard.GetComponent<Bow>() != null)
                {
                    player2Health = player2Health - player1Attack;
                    player2HealthText.text = player2Health.ToString();
                }   

                else
                {
                    player2AttackingCard.TakeDamage(player1Attack);  //Player 2's card takes damage
                }
            }
        }

        //Destroy Any cards that are killed in the attack
        for (int i = 0; i < 5; i++)
            {

                if (player1Feild[i] != null)
                {
                    Card postAttackCard = player1Feild[i].GetComponent<Card>();

                    if (postAttackCard.GetAlive() == false)
                    {
                        Destroy(player1Feild[i]);
                        player1Feild[i] = null;
                    }
                }

                if (player2Feild[i] != null)
                {
                    Card postAttackCard = player2Feild[i].GetComponent<Card>();

                    if (postAttackCard.GetAlive() == false)
                    {
                        Destroy(player2Feild[i]);
                        player2Feild[i] = null;
                    }
                }
            }
    }

    public bool GetAttacking()
    {
        return attacking;
    }

    public void DrawMonsterCard()
    {   
        if (player1playing == true || player2playing == true)
        {
            if (cardsDrawn < 3)
            {
                if (player1playing == true)
                {
                    
                    if (monsterDeck1.Count >= 1)
                    {
                        GameObject drawnCard = monsterDeck1[monsterDeck1.Count-1];
                        //CardDrawn

                        for (int i = 0; i < player1AvailableCardSlots.Length; i++)
                        {
                            if (player1AvailableCardSlots[i] == true)
                            {
                                    drawnCard.transform.position = cardSlots[i].position;
                                    player1AvailableCardSlots[i] = false;
                                    player1Hand.Add(drawnCard);
                                    monsterDeck1.Remove(monsterDeck1[monsterDeck1.Count-1]);
                                    player1MonsterLeft -= 1;
                                    monsterText.text = player1MonsterLeft.ToString();
                                    cardsDrawn += 1;   //1 more card has been drawn
                                    return;
                            }
                        }
                            
                        infoText.text = "Your Hand Is full... Remove a card first.";
                    }

                    else
                    {
                        infoText.text = "There are no more monster cards to draw!";
                    }  
                }

                //ADD PLAYER 2 Functionality
                else
                {
                    if (monsterDeck2.Count >= 1)
                    {
                        GameObject drawnCard = monsterDeck2[monsterDeck2.Count-1];
                        //CardDrawn

                        for (int i = 0; i < player2AvailableCardSlots.Length; i++)
                        {
                            if (player2AvailableCardSlots[i] == true)
                            {
                                    drawnCard.transform.position = cardSlots[i].position;
                                    player2AvailableCardSlots[i] = false;
                                    player2Hand.Add(drawnCard);
                                    monsterDeck2.Remove(monsterDeck2[monsterDeck2.Count-1]);
                                    player2MonsterLeft -= 1;
                                    monsterText.text = player2MonsterLeft.ToString();
                                    cardsDrawn += 1;   //1 more card has been drawn
                                    return;
                            }
                        }
                            
                        infoText.text = "Your Hand Is full... Remove a card first.";
                    }

                    else
                    {
                        infoText.text = "There are no more monster cards to draw!";
                    }  
                }
            }

            else
            {
                infoText.text = "!Max Cards drawn!";
            }
        }
    }

    public void DrawHeroCard()
    {
        if (player1playing == true || player2playing == true)
        {
            if (cardsDrawn < 3)
            {
                if (player1playing == true)
                {
                    if (heroDeck1.Count >= 1)
                    {
                        GameObject drawnCard = heroDeck1[heroDeck1.Count-1];
                        //CardDrawn

                        for (int i = 0; i < player1AvailableCardSlots.Length; i++)
                        {
                            if (player1AvailableCardSlots[i] == true)
                            {
                                drawnCard.transform.position = cardSlots[i].position;
                                player1AvailableCardSlots[i] = false;
                                player1Hand.Add(drawnCard);
                                heroDeck1.Remove(heroDeck1[heroDeck1.Count-1]);
                                player1HeroLeft -= 1;
                                heroText.text = player1HeroLeft.ToString();
                                cardsDrawn += 1;   //1 more card has been drawn
                                return;
                            }
                        }
                        
                        infoText.text = "Your Hand Is full... Remove a card first.";
                    }

                    else
                    {
                        infoText.text = "There are no more hero cards to draw!";
                    }
                }
                    //PLAYER 2 Functionality

                else
                {
                    if (heroDeck2.Count >= 1)
                        {
                            GameObject drawnCard = heroDeck2[heroDeck2.Count-1];
                            //CardDrawn

                            for (int i = 0; i < player2AvailableCardSlots.Length; i++)
                            {
                                if (player2AvailableCardSlots[i] == true)
                                {
                                    drawnCard.transform.position = cardSlots[i].position;
                                    player2AvailableCardSlots[i] = false;
                                    player2Hand.Add(drawnCard);
                                    heroDeck2.Remove(heroDeck2[heroDeck2.Count-1]);
                                    player2HeroLeft -= 1;
                                    heroText.text = player2HeroLeft.ToString();
                                    cardsDrawn += 1;   //1 more card has been drawn
                                    return;
                                }
                            }
                            
                            infoText.text = "Your Hand Is full... Remove a card first.";
                        }

                        else
                        {
                            infoText.text = "There are no more hero cards to draw!";
                        }   
                }
            }

            else
            {
                infoText.text = "!Max Cards drawn!";
            }
        }
        
    }

    //Chosing which game object we are currenly focusing on
    public void SetFocus(GameObject selectedCard)
    {
        focus = selectedCard;
        focused = true;
    }

    //Returning the value if any cards are focused
    public bool GetFocused()
    {
        return focused;
    }

    //Player is plays a card
    public void PlayCard(GameObject slot, int chosenIndex)
    {
        GameObject chosenSlot = slot;
        Card focusCard = focus.GetComponent<Card>();   //Getting the Card Script of the current focus

        int index = chosenIndex;
        //CardPlayed

        if (player1playing == true) //Player 1 is currently playing 
        {
            if (player1Feild[index] == null)
            {
                if (Player1PayCost() == true)
                {
                    player1Feild[index] = focus;   //Adds the focus into the feild of player 1
                    focusCard.SetCurrentFeildIndex(index);   //Tells the focus card what index it has been placed on 
                    player1Hand[player1Hand.IndexOf(focus)] = null;  //Sets the index of the focus as empty in the hand 

                    focus.transform.position = slot.transform.position; //Teleports card to chosen slot
                    Card currentFocusedCard = focus.GetComponent<Card>();   //Accesses the Card Object attached to the focus
                    currentFocusedCard.CardPlayed();   //Sets the card to active
                    CleanPlayer1Hand();
                }
            }
        }

        else  //Player 2 is currently playing 
        {
            if (player2Feild[index] == null)
            {
                if (Player2PayCost() == true)
                {
                    player2Feild[index] = focus;   //Adds the focus into the feild of player 2
                    focusCard.SetCurrentFeildIndex(index);  //Tells the focus card what index it has been placed on 
                    player2Hand[player2Hand.IndexOf(focus)] = null;  //Sets the index of the focus as empty in the hand

                    focus.transform.position = slot.transform.position; //Teleports card to chosen slot
                    Card currentFocusedCard = focus.GetComponent<Card>();   //Accesses the Card Object attached to the focus
                    currentFocusedCard.CardPlayed();   //Sets the card to active
                    CleanPlayer2Hand();
                }
            }
        }
        
        focused = false; //Defocuses the player
        focus = null;

        //Resetting the cursor
        Cursor.SetCursor(defultTexture, Vector2.zero, CursorMode.Auto);
        defaultCursor = true;
    }

    public bool Player1PayCost()
    {
        bool playable = false;

        if (focus.CompareTag("Copper"))
        {
            if (bribeInPlay == false)
            {
                if (player1Coins >= 3)
                {
                    player1Coins -= 3;
                    coinText.text = player1Coins.ToString();
                    playable = true;
                }
            }

            else
            {
                if (player1Coins >= 1)
                {   
                    player1Coins -= 1;
                    coinText.text = player1Coins.ToString();
                    playable = true;
                }

            }
            
        }

        else if (focus.CompareTag("Threat"))
        {
            if (player1SacrificeTokens >= 1)
            {
                player1SacrificeTokens -= 1;
                sacrificeText.text = player1SacrificeTokens.ToString();
                playable = true;
            }
        }

        else if (focus.CompareTag("2Blood"))
        {
            if (player1Health > 2)
            {
                player1Health -= 2;
                player1HealthText.text = player1Health.ToString();
                playable = true;
            }
        }

        else if (focus.CompareTag("3Blood"))
        {
            if (player1Health > 3)
            {
                player1Health -= 3;
                player1HealthText.text = player1Health.ToString();
                playable = true;
            }
        }

        else if (focus.CompareTag("4Blood"))
        {
            if (player1Health > 4)
            {
                player1Health -= 4;
                player1HealthText.text = player1Health.ToString();
                playable = true;
            }
        }

        else if (focus.CompareTag("5Blood"))
        {
            if (player1Health > 5)
            {
                player1Health -= 5;
                player1HealthText.text = player1Health.ToString();
                playable = true;
            }
        }

        else if (focus.CompareTag("6Blood"))
        {
            if (player1Health > 6)
            {
                player1Health -= 6;
                player1HealthText.text = player1Health.ToString();
                playable = true;
            }
        }

        else if (focus.CompareTag("8Blood"))
        {
            if (player1Health > 8)
            {
                player1Health -= 8;
                player1HealthText.text = player1Health.ToString();
                playable = true;
            }
        }

        else if (focus.CompareTag("10Blood"))
        {
            if (player1Health > 10)
            {
                player1Health -= 10;
                player1HealthText.text = player1Health.ToString();
                playable = true;
            }
        }

        else if (focus.CompareTag("Silver"))
        {
            if (bribeInPlay == false)
            {
                if (player1Coins >= 6)
                {
                    player1Coins -= 6;
                    coinText.text = player1Coins.ToString();
                    playable = true;
                }
            }

            else
            {
                if (player1Coins >= 4)
                {
                    player1Coins -= 4;
                    coinText.text = player1Coins.ToString();
                    playable = true;
                }
            }
            
        }

        else if (focus.CompareTag("Monster"))
        {
            if (player1SacrificeTokens >= 2)
            {
                player1SacrificeTokens -= 2;
                sacrificeText.text = player1SacrificeTokens.ToString();
                playable = true;
            }
        }

        else if (focus.CompareTag("Gold"))
        {
            if (bribeInPlay == false)
            {
                if (player1Coins >= 9)
                {
                    player1Coins -= 9;
                    coinText.text = player1Coins.ToString();
                    playable = true;
                }
            }

            else
            {
                if (player1Coins >= 7)
                {
                    player1Coins -= 7;
                    coinText.text = player1Coins.ToString();
                    playable = true;
                }
            }
        }

        else if (focus.CompareTag("Free"))
        {
            playable = true;
        }

        else //Horror
        {
            if (player1SacrificeTokens >= 3)
            {
                player1SacrificeTokens -= 3;
                sacrificeText.text = player1SacrificeTokens.ToString();
                playable = true;
            }
        }

        return playable;
    }


    public bool Player2PayCost()
    {
        bool playable = false;

        if (focus.CompareTag("Copper"))
        {
            if (bribeInPlay == false)
            {
                if (player2Coins >= 3)
                {
                    player2Coins -= 3;
                    coinText.text = player2Coins.ToString();
                    playable = true;
                }
            }

            else
            {
                if (player2Coins >= 1)
                {   
                    player2Coins -= 1;
                    coinText.text = player2Coins.ToString();
                    playable = true;
                }

            }
        }

        else if (focus.CompareTag("Threat"))
        {
            if (player2SacrificeTokens >= 1)
            {
                player2SacrificeTokens -= 1;
                sacrificeText.text = player2SacrificeTokens.ToString();
                playable = true;
            }
        }

        else if (focus.CompareTag("2Blood"))
        {
            if (player2Health > 2)
            {
                player2Health -= 2;
                player2HealthText.text = player2Health.ToString();
                playable = true;
            }
        }

        else if (focus.CompareTag("3Blood"))
        {
            if (player2Health > 3)
            {
                player2Health -= 3;
                player2HealthText.text = player2Health.ToString();
                playable = true;
            }
        }

        else if (focus.CompareTag("4Blood"))
        {
            if (player2Health > 4)
            {
                player2Health -= 4;
                player2HealthText.text = player2Health.ToString();
                playable = true;
            }
        }

        else if (focus.CompareTag("5Blood"))
        {
            if (player2Health > 5)
            {
                player2Health -= 5;
                player2HealthText.text = player2Health.ToString();
                playable = true;
            }
        }

        else if (focus.CompareTag("6Blood"))
        {
            if (player2Health > 6)
            {
                player2Health -= 6;
                player2HealthText.text = player2Health.ToString();
                playable = true;
            }
        }

        else if (focus.CompareTag("8Blood"))
        {
            if (player2Health > 8)
            {
                player2Health -= 8;
                player2HealthText.text = player2Health.ToString();
                playable = true;
            }
        }

        else if (focus.CompareTag("10Blood"))
        {
            if (player2Health > 10)
            {
                player2Health -= 10;
                player2HealthText.text = player2Health.ToString();
                playable = true;
            }
        }

        else if (focus.CompareTag("Silver"))
        {
            if (bribeInPlay == false)
            {
                if (player2Coins >= 6)
                {
                    player2Coins -= 6;
                    coinText.text = player2Coins.ToString();
                    playable = true;
                }
            }

            else
            {
                if (player2Coins >= 4)
                {
                    player2Coins -= 4;
                    coinText.text = player2Coins.ToString();
                    playable = true;
                }
            }
        }

        else if (focus.CompareTag("Monster"))
        {
            if (player2SacrificeTokens >= 2)
            {
                player2SacrificeTokens -= 2;
                sacrificeText.text = player2SacrificeTokens.ToString();
                playable = true;
            }
        }

        else if (focus.CompareTag("Gold"))
        {
            if (bribeInPlay == false)
            {
                if (player2Coins >= 9)
                {
                    player2Coins -= 9;
                    coinText.text = player2Coins.ToString();
                    playable = true;
                }
            }

            else
            {
                if (player2Coins >= 7)
                {
                    player2Coins -= 7;
                    coinText.text = player2Coins.ToString();
                    playable = true;
                }
            }
        }

        else if (focus.CompareTag("Free"))
        {
            playable = true;
        }

        else //Horror
        {
            if (player2SacrificeTokens >= 3)
            {
                player2SacrificeTokens -= 3;
                sacrificeText.text = player2SacrificeTokens.ToString();
                playable = true;
            }
        }

        return playable;
    }

    public void SacrificeMode()
    {
        if (player1playing == true || player2playing == true)
        {
            Cursor.SetCursor(sacrificeTexture, Vector2.zero, CursorMode.Auto);
            defaultCursor = false;
            sacrificing = true;
        }
    }

    public bool GetSacrificing()
    {
        return sacrificing;
    }

    public void Sacrifice(int currentFeildIndex)
    {
        
        if (player1playing == true)
        {
            player1SacrificeTokens += 1;
            player1DiscardSize += 1;
            sacrificeText.text = player1SacrificeTokens.ToString();
            discardText.text = player1DiscardSize.ToString();
            player1Feild[currentFeildIndex] = null;
            //CleanPlayer1Feild();
        }

        else
        {
            player2SacrificeTokens += 1;
            player2DiscardSize += 1;
            sacrificeText.text = player2SacrificeTokens.ToString();
            discardText.text = player2DiscardSize.ToString();
            player2Feild[currentFeildIndex] = null;
        }

        Defocus();
    }

    public void LoadPlayer1()
    {
        cardsDrawn = 0;
        monsterText.text = player1MonsterLeft.ToString();
        heroText.text = player1HeroLeft.ToString();
        discardText.text = player1DiscardSize.ToString();
        coinText.text = player1Coins.ToString();
        sacrificeText.text = player2SacrificeTokens.ToString();
        player1HealthText.text = player1Health.ToString();
        infoText.text = "ROUND: " + turnTotal.ToString() + "                      " + "COINS GAINED: " + coinsGained.ToString() + "                      " + "- [PLAYER 1 TO PLAY] -";
        //Load previous player 2 health from last attack turn

        //Reload the cards of the player
        for (int i = 0; i < player1Hand.Count; i++)
        {
            player1Hand[i].transform.position = cardSlots[i].position;
        }
        
        for (int i = 0; i < player1Feild.Length; i++)
        {
            if (player1Feild[i] != null)
            {
                player1Feild[i].transform.position = lowerFeildSlots[i].position;
            }
        }

    }
    
    public void DeloadPlayer1()
    {
        for (int i = 0; i < player1Hand.Count; i++)
        {
            player1Hand[i].transform.position = player1DeloadSlot.position;
        }

        for (int i = 0; i < player1Feild.Length; i++)
        {
            if (player1Feild[i] != null)
            {
                player1Feild[i].transform.position = player1DeloadSlot.position;
            }
        }
    }

    public void LoadPlayer2()
    {
        cardsDrawn = 0;
        monsterText.text = player2MonsterLeft.ToString();
        heroText.text = player2HeroLeft.ToString();
        discardText.text = player2DiscardSize.ToString();
        coinText.text = player2Coins.ToString();
        sacrificeText.text = player2SacrificeTokens.ToString();
        player2HealthText.text = player2Health.ToString();
        infoText.text = "ROUND: " + turnTotal.ToString() + "                      " + "COINS GAINED: " + coinsGained.ToString() + "                      " + "- [PLAYER 2 TO PLAY] -";
        gameBoardSprite.flipY = true;

        //Reload the cards of the player
        for (int i = 0; i < player2Hand.Count; i++)
        {
            player2Hand[i].transform.position = cardSlots[i].position;
        }
        
        for (int i = 0; i < player2Feild.Length; i++)
        {
            if (player2Feild[i] != null)
            {
                player2Feild[i].transform.position = lowerFeildSlots[i].position;
            }
        }
    }

    public void DeloadPlayer2()
    {
        for (int i = 0; i < player2Hand.Count; i++)
        {
            player2Hand[i].transform.position = player2DeloadSlot.position;
        }

        for (int i = 0; i < player2Feild.Length; i++)
        {
            if (player2Feild[i] != null)
            {
                player2Feild[i].transform.position = player2DeloadSlot.position;
            }
        }
        
        gameBoardSprite.flipY = false;
    }

    public void DeloadAll()
    {
        for (int i = 0; i < player1Feild.Length; i++)
        {
            if (player1Feild[i] != null)
            {
                player1Feild[i].transform.position = player1DeloadSlot.position;
            }
        }

        for (int i = 0; i < player2Feild.Length; i++)
        {
            if (player2Feild[i] != null)
            {
                player2Feild[i].transform.position = player2DeloadSlot.position;
            }
        }
    }

    public void Defocus()
    {
        focused = false;
        focus = null;
        sacrificing = false;
        Cursor.SetCursor(defultTexture, Vector2.zero, CursorMode.Auto);
        defaultCursor = true;
    }

    public string GetCurrentPlaying()
    {
        if (player1playing == true)
        {
            return "Player1";
        }

        else if (player2playing == true)
        {
            return "Player2";
        }

        else
        {
            return "None";
        }
    }

    public void CleanPlayer1Hand()
    {
        int nonZeroIndex = 0;

        for (int i = 0; i < player1Hand.Count; i++)
        {
            if (player1Hand[i] != null)
            {
                // Move the card to the leftmost possible slot
                player1Hand[nonZeroIndex] = player1Hand[i];
                player1Hand[nonZeroIndex].transform.position = cardSlots[nonZeroIndex].position;

                // If the nonZeroIndex is different from the current index, set the current index to null
                if (nonZeroIndex != i)
                {
                    player1Hand[i] = null;
                }

                nonZeroIndex += 1;
            }
        }

        for (int i = 0; i < player1AvailableCardSlots.Length; i++)
            {
                player1AvailableCardSlots[i] = true;
            }

        for (int i = 0; i < player1Hand.Count; i++)
        {
            if (player1Hand[i] == null)
            {
                player1Hand.RemoveAt(i);
            }

            else
            {
                player1AvailableCardSlots[i] = false;
            }
        }
    }

    public void CleanPlayer2Hand()
    {
        int nonZeroIndex = 0;

        for (int i = 0; i < player2Hand.Count; i++)
        {
            if (player2Hand[i] != null)
            {
                // Move the card to the leftmost possible slot
                player2Hand[nonZeroIndex] = player2Hand[i];
                player2Hand[nonZeroIndex].transform.position = cardSlots[nonZeroIndex].position;

                // If the nonZeroIndex is different from the current index, set the current index to null
                if (nonZeroIndex != i)
                {
                    player2Hand[i] = null;
                }

                nonZeroIndex += 1;
            }
        }

        for (int i = 0; i < player2AvailableCardSlots.Length; i++)
            {
                player2AvailableCardSlots[i] = true;
            }

        for (int i = 0; i < player2Hand.Count; i++)
        {
            if (player2Hand[i] == null)
            {
                player2Hand.RemoveAt(i);
            }

            else
            {
                player2AvailableCardSlots[i] = false;
            }
        }
    }

    public int GetPlayer1SacrificeTokens()
    {
        return player1SacrificeTokens;
    }

    public int GetPlayer2SacrificeTokens()
    {
        return player2SacrificeTokens;
    }

    public GameObject[] GetPlayer1Feild()
    {
        return player1Feild;
    }

    public GameObject[] GetPlayer2Feild()
    {
        return player2Feild;
    }

    public Transform[] GetLowerFeildSlots()
    {
       return lowerFeildSlots;
    }

    public Transform[] GetHigherFeildSlots()
    {
       return higherFeildSlots;
    }

    public List<GameObject> GetPlayer1Hand()
    {
        return player1Hand;
    }

    public List<GameObject> GetPlayer2Hand()
    {
        return player2Hand;
    }

    public bool[] GetPlayer1AvailableCardSlots()
    {
        return player1AvailableCardSlots;
    }

    public bool[] GetPlayer2AvailableCardSlots()
    {
        return player2AvailableCardSlots;
    }

    public Transform[] GetCardSlots()
    {
        return cardSlots;
    }
    
    public bool GetGameRunning()
    {
        return gameRunning;
    }

    public void GameOver()
    {
        //Swap to the game over Scene
        //SceneManager.LoadScene(x)
    }

    public void GameExit()
    {
        //Game Has Forcfully Ended
        SceneManager.LoadScene(0);
    }

    public IEnumerator Wait2Seconds()
    {
        yield return new WaitForSeconds(2f);
    }

    //Called when a DeluxeSacrifice is sacrificed so that player gets +2
    public void DeluxeSacrifice()
    {
        if (player1playing == true)
        {
            player1SacrificeTokens += 1;
            sacrificeText.text = player1SacrificeTokens.ToString();
        }

        else
        {
            player2SacrificeTokens += 1;
            sacrificeText.text = player2SacrificeTokens.ToString();
        }
    }

    //Called when a Bribe Card is played 
    public void BribePlayed()
    {
        bribeInPlay = true;
    }

    public void Player1TakeDamage(int incoming)
    {
        player1Health = player1Health - incoming;
        player1HealthText.text = player1Health.ToString();
    }

    public void Player2TakeDamage(int incoming)
    {
        player2Health = player2Health - incoming;
        player2HealthText.text = player2Health.ToString();
    }

    public int GetCurrentTurn()
    {
        return turnTotal;
    }

}
