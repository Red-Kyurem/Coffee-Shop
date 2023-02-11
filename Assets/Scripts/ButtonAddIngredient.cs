using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAddIngredient : MonoBehaviour
{
    public string IngredientString = "";
    public GameObject cup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddIngredient()
    {
        Debug.Log("HITTTT!!!");

        
            Debug.Log("PRESSED!!!");
            

        if (cup != null && cup.GetComponent<PickupableObject>().objectType == ObjectType.Cup)
        {
            cup.GetComponent<CupContents>().ingredientStrings.Add(IngredientString);
        }
        
    }
}
