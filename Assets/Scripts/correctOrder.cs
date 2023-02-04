using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class correctOrder : MonoBehaviour
{
    public List<string> orderStrings;
    public bool hasEnteredButNotActivated = false;
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
            Debug.Log("ENTERED!!!");
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
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.GetComponent<CupContents>())
        {
            hasEnteredButNotActivated = false;
            Debug.Log("EXITED!!!");
            //collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }

    }
}
