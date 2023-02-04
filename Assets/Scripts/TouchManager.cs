using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public List<GameObject> PickupReciever;
    correctOrder correctOrderScript;
    // Start is called before the first frame update
    void Start()
    {
        correctOrderScript = GetComponent<correctOrder>();
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
                    List<string> cupIngredientStrings = GetComponent<PickupReciever>().ObjectRecieved.GetComponent<CupContents>().ingredientStrings;
                    List<string> orderIngredientStrings = correctOrderScript.orderStrings;
                    bool isCupCorrect = true;

                    if (orderIngredientStrings.Count != cupIngredientStrings.Count)
                    {
                        isCupCorrect = false;
                    }
                    

                    int orderLength = orderIngredientStrings.Count;
                    int cupLength = cupIngredientStrings.Count;

                    orderIngredientStrings.Sort();
                    cupIngredientStrings.Sort();

                    
                    for (int IngredientIndex = 0; IngredientIndex < orderLength; IngredientIndex++)
                    {
                        if (orderIngredientStrings[IngredientIndex] != cupIngredientStrings[IngredientIndex])
                        {
                            isCupCorrect = false;
                        }
                        if (!isCupCorrect) { break; }
                    }
                    

                    if (isCupCorrect)
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
