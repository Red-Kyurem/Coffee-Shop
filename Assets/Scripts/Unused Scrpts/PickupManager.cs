using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public GameObject pickedUpObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //creates a raycast and sets it to the mouses cursor position in the game world
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            //draw invisible ray 
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            //log hit area to the console
            //Debug.Log(hit.point);
        }

        if (Input.GetButtonDown("LeftClick"))
        {
            if (pickedUpObject == null)
            {
                if (Physics.Raycast(ray, out hit, 100))
                {
                    if (hit.collider.tag == "PickupableObject")
                    {
                        pickedUpObject = hit.collider.gameObject;
                        pickedUpObject.GetComponent<PickupObject>().isPickedUp = true;
                    }
                    if (hit.collider.tag == "PickupReciever")
                    {
                    }
                }
            }

        }
        else if (Input.GetButtonUp("LeftClick") && pickedUpObject != null)
        {
            pickedUpObject.GetComponent<PickupObject>().isPickedUp = false;
            pickedUpObject = null;
        }
        if (pickedUpObject != null)
        {

            pickedUpObject.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                                            Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                                                            pickedUpObject.transform.position.z);
        }
    }
}
