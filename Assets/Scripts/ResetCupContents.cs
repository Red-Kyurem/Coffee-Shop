using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCupContents : MonoBehaviour
{

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.GetComponent<CupContents>())
        {
            collider.gameObject.GetComponent<CupContents>().ingredientStrings.Clear();
        }
    }
}
