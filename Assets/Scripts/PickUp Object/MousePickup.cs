using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePickup : MonoBehaviour
{
    public Vector3 Mouse_Position;
    Vector3 MouseWorldPosition;

    public GameObject SelectedGM;
    public GameObject HighlightedGM;
    public float SelectedGMForwardOffset;
    Rigidbody rb;

    public bool canPickUp = false;
    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {
        if (canPickUp)
        {
            LayerMask pickupLayerMask = 1 << 6;
            LayerMask buttonLayerMask = 1 << 7;

            Mouse_Position = Input.mousePosition;
            Mouse_Position.z = Camera.main.nearClipPlane;
            MouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Mouse_Position.x, Mouse_Position.y, 0));


            // World_Position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000, pickupLayerMask) && SelectedGM == null)
            {

                //Debug.Log("pickup!!!");
                HighlightedGM = hit.transform.gameObject;

                // if mouse is hovering over and gameobject is clicked on, then pick up gameobject
                if (HighlightedGM.GetComponent<PickupableObject>() && Input.GetMouseButton(0))
                {
                    if (HighlightedGM.GetComponent<PickupableObject>().canBePickedUp)
                    {
                        // ADD TELEMETRY HERE (ObjectClickedOn)


                        SelectedGM = HighlightedGM;
                        HighlightedGM = null;
                        rb = SelectedGM.GetComponent<Rigidbody>();
                        SelectedGM.GetComponent<PickupableObject>().isPickedUp = true;
                        if (SelectedGM.GetComponent<CupContents>())
                        {
                            SelectedGM.GetComponent<CupContents>().ResetInGameButtons();
                        }
                    }
                }
                
                else if (HighlightedGM.GetComponent<PickupableObject>())
                {
                    HighlightedGM = null;
                }
            }
            else
            {
                // if gameobject is not clicked on, then drop gameobject
                HighlightedGM = null;
                if (Input.GetMouseButtonUp(0) && SelectedGM != null)
                {
                    DropObject();

                }
            }

            if (Physics.Raycast(ray, out hit, 1000, buttonLayerMask) && Input.GetMouseButtonDown(0))
            {
                // ADD TELEMETRY HERE (ObjectClickedOn)

                //Debug.Log("PRESSED!!!");
                hit.transform.gameObject.GetComponent<ButtonAddIngredient>().AddIngredient();
            }


            // when the selected gameobject is picked up
            if (SelectedGM != null && SelectedGM.GetComponent<PickupableObject>())
            {
                rb.velocity = Vector3.zero;
                SelectedGM.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Mouse_Position.x, Mouse_Position.y, Camera.main.transform.position.z+ SelectedGMForwardOffset));
            }

            Debug.DrawRay(ray.origin, ray.direction * 25, Color.red);

        }
    }

    public void DropObject()
    {
        Vector3 selectedPos = SelectedGM.transform.position;
        selectedPos.z = 0;
        MouseWorldPosition.z = 0;
        rb.velocity = (MouseWorldPosition - selectedPos).normalized * ((MouseWorldPosition - selectedPos).magnitude / Time.deltaTime / 5);
        rb.velocity = Vector3.zero;
        SelectedGM.GetComponent<PickupableObject>().isPickedUp = false;
        SelectedGM = null;
    }
}
