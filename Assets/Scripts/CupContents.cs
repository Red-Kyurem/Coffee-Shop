using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupContents : MonoBehaviour
{
    public List<string> ingredientStrings;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetInGameButtons()
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("In-Game Button");
        for (int i = 0; i< buttons.Length; i++)
        {
            buttons[i].GetComponent<ButtonAddIngredient>().cup = null;
        }
    }
}
