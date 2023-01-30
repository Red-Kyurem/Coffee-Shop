using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public List<GameObject> PickupRecievers;
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
            if (Physics.Raycast(ray, out hit, 100))
            {
                dialouge_TEST dialougeScript = GameObject.FindGameObjectWithTag("DialougeManager").GetComponent<dialouge_TEST>();

                if (hit.collider.tag == "ConfirmOrder" && dialougeScript.isSentenceFilledIn == true)
                {
                    if (PickupRecievers[0].GetComponent<PickupReciever>().ObjectRecieved != null && PickupRecievers[0].GetComponent<PickupReciever>().ObjectRecieved.GetComponent<ItemValue>().orderNum == GameObject.FindGameObjectWithTag("ConfirmOrder").GetComponent<correctOrder>().orderNums[0]
                    && PickupRecievers[1].GetComponent<PickupReciever>().ObjectRecieved != null && PickupRecievers[1].GetComponent<PickupReciever>().ObjectRecieved.GetComponent<ItemValue>().orderNum == GameObject.FindGameObjectWithTag("ConfirmOrder").GetComponent<correctOrder>().orderNums[1]
                    && PickupRecievers[2].GetComponent<PickupReciever>().ObjectRecieved != null && PickupRecievers[2].GetComponent<PickupReciever>().ObjectRecieved.GetComponent<ItemValue>().orderNum == GameObject.FindGameObjectWithTag("ConfirmOrder").GetComponent<correctOrder>().orderNums[2])
                    {
                        Debug.Log("Correct!");
                        
                        dialougeScript.PrepareNextSentence(dialougeScript.CheckForMatchingBubbleName("<\\BUBBLE>CorrectOrder"));
                    }
                    else
                    {
                        Debug.Log("INcorrect!");
                        dialougeScript.PrepareNextSentence(dialougeScript.CheckForMatchingBubbleName("<\\BUBBLE>IncorrectOrder"));
                    }

                }
                else if (hit.collider.tag == "RestartOrder")
                {

                }
                else if (hit.collider.tag == "SpawnItem")
                {
                    Instantiate(hit.collider.GetComponent<SpawnItem>().itemToSpawn, hit.collider.transform.position+Vector3.forward*-1, Quaternion.identity);
                }
            }

        }

    }
}
