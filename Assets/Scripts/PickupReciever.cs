using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupReciever : MonoBehaviour
{
    public GameObject ObjectRecieved;
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
        Debug.Log(other.name);
            if (other.gameObject.tag == "PickupableObject" && other.gameObject.GetComponent<PickupObject>().isPickedUp == false)
            {
                other.transform.position = transform.position + Vector3.forward * -0.005f;
                ObjectRecieved = other.gameObject;
            }
        

    }
    public void OnTriggerExit(Collider other)
    {
        if (ObjectRecieved == other.gameObject)
        {
            ObjectRecieved = null; 
        }
    }
}
