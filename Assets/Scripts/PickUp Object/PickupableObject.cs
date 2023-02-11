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
    public Vector3 startingLocation;
    // Start is called before the first frame update
    void Start()
    {
        startingLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
