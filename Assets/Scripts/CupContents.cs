using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupContents : MonoBehaviour
{
    public List<string> ingredientStrings;

    GameObject cupFill;

    private void Start()
    {
        cupFill = transform.GetChild(1).gameObject;
    }

    private void Update()
    {
       if( ingredientStrings.Count == 0)
        {
            cupFill.SetActive(false);
        }

        else
        {
            cupFill.SetActive(true);
        }
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
