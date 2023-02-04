using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    None,
    Cup,
    Beans,
    Milk,
    Syrup,
    Toppings,
    Extras,
    Ice
}

public class PickupableObject : MonoBehaviour
{
    public ObjectType objectType;
    public bool canBePickedUp = true;
    public bool isPickedUp = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
