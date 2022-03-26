using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boosts : MonoBehaviour
{
    [Tooltip("Multiply,Plus")]
    [SerializeField]  string type = "Multiply, Plus";
    [SerializeField]  int number;
    
    [HideInInspector] public const string multiplyKey = "Multiply";
    [HideInInspector] public const string plusKey = "Plus";
    

    public int GetNumber()
    {
        return number;
    }

    public string GetSign()
    {
        return type;
    }
}
