using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class correctOrder : MonoBehaviour
{
    public List<string> orderStrings;
    public bool hasEnteredButNotActivated = false;

    


    public string correctOrderName = "";
    public string incorrectOrderName = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<CupContents>())
        {
            hasEnteredButNotActivated = true;
            //Debug.Log("ENTERED!!!");
            //collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;



        }
        
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.GetComponent<CupContents>() && hasEnteredButNotActivated)
        {
            dialouge_TEST dialougeScript = GameObject.FindGameObjectWithTag("DialougeManager").GetComponent<dialouge_TEST>();

            if (dialougeScript.isSentenceFilledIn == true)
            {
                // it has now been activated
                hasEnteredButNotActivated = false;

                List<string> cupIngredientStrings = collider.gameObject.GetComponent<CupContents>().ingredientStrings;
                List<string> orderIngredientStrings = orderStrings;
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
                    if (cupLength > 0 && orderIngredientStrings[IngredientIndex] != cupIngredientStrings[IngredientIndex])
                    {
                        isCupCorrect = false;
                    }
                    if (!isCupCorrect) { break; }
                }


                if (isCupCorrect)
                {
                    TelemetryLogger.Log(this, "Success");

                    dialougeScript.PrepareNextSentence(dialougeScript.CheckForMatchingBubbleName(correctOrderName));
                }
                else
                {
                    TelemetryLogger.Log(this, "Fail");
                    dialougeScript.PrepareNextSentence(dialougeScript.CheckForMatchingBubbleName(incorrectOrderName));
                }


            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.GetComponent<CupContents>())
        {
            hasEnteredButNotActivated = false;
            //Debug.Log("EXITED!!!");
            //collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }

    }
}
