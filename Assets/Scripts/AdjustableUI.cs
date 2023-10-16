using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustableUI : MonoBehaviour
{
    [SerializeField] private Vector2 defualtSize;
    [SerializeField] private RectTransform uiElement; // Reference to the UI element (e.g., Image, Panel)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateSize(int sizeMultiplier)
    {
        Vector2 newSize = new Vector2((defualtSize.x * sizeMultiplier), (defualtSize.y * sizeMultiplier));
        uiElement.sizeDelta = newSize;
    }

}
