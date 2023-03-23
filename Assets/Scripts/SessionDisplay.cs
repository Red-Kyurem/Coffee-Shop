using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SessionDisplay : MonoBehaviour
{
    
    public void OnConnectionSuccess(int sessionID)
    {
        TextMeshProUGUI displayField = GetComponent<TextMeshProUGUI>();
        
        if (sessionID < 0)
        {
            displayField.text = $"Session Number ID: {sessionID} (local)";
        }
        else
        {
            displayField.text = $"Session Number ID: {sessionID} (server)";
        }
    }


    public void OnConnectionFail(string errorMessage)
    {
        TextMeshProUGUI displayField = GetComponent<TextMeshProUGUI>();
        displayField.text = $"Connection Failed, Error: {errorMessage}";
    }


}
