using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickupReciever : MonoBehaviour
{
    public GameObject ObjectRecieved;
    public List<ObjectType> placeableObjectTypes;
    public Vector3 objectOffset;
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
        Debug.Log(other.name);
        bool canCompareObj = false;
        


            if (other.gameObject.tag == "PickupableObject" && 
            otherPO.isPickedUp == false && 
            canCompareObject(placeableObjectTypes, otherPO.objectType))
            {
                other.transform.position = transform.parent.position + objectOffset;
                //other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().velocity = Vector3.zero;
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
