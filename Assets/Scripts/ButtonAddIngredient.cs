using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAddIngredient : MonoBehaviour
{
    public string IngredientString = "";
    public GameObject cup;
    private Color buttonColor;
    public Color pressedButtonColor = new Color(1, 0.33f, 0.33f);
    GameObject tCoffeePour;
    // Start is called before the first frame update
    void Start()
    {
        buttonColor = GetComponent<Renderer>().material.color;
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
            tCoffeePour.SetActive(true);
            GetComponent<Renderer>().material.color = pressedButtonColor;
            Invoke("ResetColor", 0.25f);

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
        tCoffeePour.SetActive(false);
    }
}
