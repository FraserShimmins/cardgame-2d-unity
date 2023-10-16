using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeluxeSacrifice : MonoBehaviour
{
    [SerializeField] private MainMethod main;
    [SerializeField] private GameObject mainMethod;

    void OnDestroy()
    {
        if (main.GetAttacking() == false)
        {
            main.DeluxeSacrifice();
        }
    }
}
