using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvalibleSlot : MonoBehaviour
{
    [SerializeField] private MainMethod main;
    [SerializeField] private GameObject mainMethod;
    [SerializeField] private SpriteRenderer spriteRenderer;
    


    // Start is called before the first frame update
    void Start()
    {
        main = mainMethod.GetComponent<MainMethod>(); //Gets the gameManager script attached to that object 
    }

    public void ShowSlot()
    {
        spriteRenderer.enabled= true;
    }

    public void HideSlot()
    {
        spriteRenderer.enabled= false;
    }
}
