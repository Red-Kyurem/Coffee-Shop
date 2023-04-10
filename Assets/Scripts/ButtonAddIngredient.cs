using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAddIngredient : MonoBehaviour
{
    public string IngredientString = "";
    public GameObject cup;
    private Color buttonColor;
    public Color pressedButtonColor = new Color(1, 0.33f, 0.33f);
    public GameObject tCoffeePour;
    void Awake()
    {
        tCoffeePour = GameObject.FindGameObjectWithTag("Splash");
    }
        // Start is called before the first frame update
    void Start()
    {
        buttonColor = GetComponent<Renderer>().material.color;
        tCoffeePour.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddIngredient()
    {

        if (cup != null && cup.GetComponent<PickupableObject>().objectType == ObjectType.Cup)
        {
            cup.GetComponent<CupContents>().ingredientStrings.Add(IngredientString);
            
            GetComponent<Renderer>().material.color = pressedButtonColor;
            Invoke("ResetColor", 0.25f);
            if (IngredientString == "Blonde" || IngredientString == "Decaf" || IngredientString == "Dark") 
            { 
                tCoffeePour.SetActive(true); 
                Invoke("HideSplash", 0.5f); 
            }
            

            // ADD TELEMETRY HERE (IngredientAdded)
            string cupContentsCombinedString = string.Join(", ", cup.GetComponent<CupContents>().ingredientStrings);

            var data = new TelemetryStructs.ingredientAddedData()
            {
                ingredientName = IngredientString,
                cupContents = cupContentsCombinedString
            };

            TelemetryLogger.Log(this, "Add Ingredient", data);

        }

    }
    public void ResetColor()
    {
        GetComponent<Renderer>().material.color = buttonColor;
    }
    public void HideSplash()
    {
        tCoffeePour.SetActive(false);
    }
}
