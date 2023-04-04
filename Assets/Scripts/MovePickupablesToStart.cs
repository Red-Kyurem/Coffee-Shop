using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePickupablesToStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<PickupableObject>())
        {
            PickupableObject otherPO = other.gameObject.GetComponent<PickupableObject>();

            if (other.gameObject.tag == "PickupableObject" && otherPO.isPickedUp == false)
            {
                other.transform.position = otherPO.startingLocation;
            }
        }
    }
}
