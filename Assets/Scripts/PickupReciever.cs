using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickupReciever : MonoBehaviour
{
    public GameObject ObjectRecieved;
    public List<ObjectType> placeableObjectTypes;
    public Vector3 objectOffset;
    public GameObject[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerStay(Collider other)
    {
        PickupableObject otherPO = other.gameObject.GetComponent<PickupableObject>();
        //Debug.Log(other.name);
        


        if (other.gameObject.tag == "PickupableObject" && otherPO.isPickedUp == false && canCompareObject(placeableObjectTypes, otherPO.objectType))
        {
            if (otherPO.objectType == ObjectType.Cup)
            {
                other.transform.position = transform.parent.position + objectOffset;
                //other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().velocity = Vector3.zero;
                ObjectRecieved = other.gameObject;

                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].GetComponent<ButtonAddIngredient>().cup = other.gameObject;
                }
            }
            else if (otherPO.objectType == ObjectType.Milk)
            {
                other.transform.position = otherPO.startingLocation;
                other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }



            // ADD TELEMETRY HERE (ObjectUsed)
            var ingredientData = new TelemetryStructs.objectUsedData()
            {
                objectName = this.transform.parent.name,
                objectRecievedName = other.name
            };
            TelemetryLogger.Log(this, "Object Used", ingredientData);
            // End of TELEMETRY




            if (transform.parent && transform.parent.gameObject.GetComponent<CupContents>())
            {

                if (transform.parent.gameObject.GetComponent<CupContents>().ingredientStrings.Count == 0)
                {
                    ColorChange.instance.SetStartColor(false);
                }
                else if (ColorChange.instance.index >= 3)
                {
                    ColorChange.instance.ResetIndex();
                    ColorChange.instance.SetStartColor(false);
                }
                else ColorChange.instance.ChangeColor(true);

                transform.parent.gameObject.GetComponent<CupContents>().ingredientStrings.Add(other.gameObject.GetComponent<ItemValue>().IngredientString);
                



                // ADD TELEMETRY HERE (IngredientAdded)
                string ingredientsCombinedString = string.Join(", ", other.gameObject.GetComponent<ItemValue>().IngredientString);
                string cupContentsCombinedString = string.Join(", ", transform.parent.gameObject.GetComponent<CupContents>().ingredientStrings);
                var data = new TelemetryStructs.ingredientAddedData()
                {
                    ingredientName = ingredientsCombinedString,
                    cupContents = cupContentsCombinedString
                };
                TelemetryLogger.Log(this, "Add Ingredient", data);
                // End of TELEMETRY

            }

        }
        

    }
    public void OnTriggerExit(Collider other)
    {
        if (ObjectRecieved == other.gameObject)
        {
            ObjectRecieved = null; 
        }
    }

    public bool canCompareObject(List<ObjectType> placeableObjs, ObjectType Obj)
    {
        for (int i = 0; i < placeableObjectTypes.Count; i++)
        {
            if (placeableObjs[i] == Obj)
            {
                return true;
            }
        }
        return false;
    }
}
