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
    }

    [System.Serializable]
    struct objectClickedOnData
    {
        public string ObjectName;
        public Vector3 ObjectPositionWorldSpace;
        public Vector2 positionInScreenSpace;
    }

    [System.Serializable]
    struct objectUsedData
    {
        public string ObjectName;
        public string objectRecievedName;
    }

    [System.Serializable]
    struct ingredientAddedData
    {
        public string ingredientName;
        public string[] cupContents;
    }

    [System.Serializable]
    struct servedCupData
    {
        public string[] cupContents;
        public string[] correctOrder;
        public float totalTimeToComplete;
    }
}
