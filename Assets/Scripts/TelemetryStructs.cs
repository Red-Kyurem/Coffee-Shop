using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelemetryStructs : MonoBehaviour
{
    [System.Serializable]
    public struct dialougeData
    {
        public bool hasDialougeAdvanced;
        public Vector2 positionInScreenSpace;
        public string choiceName;
        public string timeStamp;
    }

    [System.Serializable]
    public struct dialougeClicksData
    {
        public bool hasDialougeAdvanced;
        public Vector2 positionInScreenSpace;
        public Vector3 positionInWorldSpace;
        public string choiceName;
        public string timeStamp;
    }

    [System.Serializable]
    public struct gameplayClicksData
    {
        public bool hasDialougeAdvanced;
        public Vector2 positionInScreenSpace;
        public Vector3 positionInWorldSpace;
        public string choiceName;
        public string timeStamp;
    }

    [System.Serializable]
    public struct objectClickedOnData
    {
        public string ObjectName;
        public Vector3 ObjectPositionWorldSpace;
        public Vector2 positionInScreenSpace;
    }

    [System.Serializable]
    public struct objectUsedData
    {
        public string objectName;
        public string objectRecievedName;
    }

    [System.Serializable]
    public struct ingredientAddedData
    {
        public string ingredientName;
        public string cupContents;
    }


    //Kien- I found it easier to use string and just convert everything else to string instead of string array and floats. :)
    [System.Serializable]
    public struct servedCupData
    {
        public string cupContents;
        public string correctOrder;
        public bool madeCorrectOrder;
        public string timeToComplete;
    }
}
