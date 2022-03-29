using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Boosts : MonoBehaviour
{
    [Tooltip("Multiply,Plus")]
    [SerializeField]  string type = "Multiply, Plus";
    [SerializeField]  int number;
    TextMeshProUGUI numberText;


    [HideInInspector] public const string multiplyKey = "Multiply";
    [HideInInspector] public const string plusKey = "Plus";

    void Awake()
    {
        Canvas mycanvas = GetComponentInChildren<Canvas>();
        numberText = GetComponentInChildren<TextMeshProUGUI>();
        
    }
    void Start()
    {
        WriteSign();
    }

    public int GetNumber()
    {
        return number;
    }

    public string GetSign()
    {
        return type;
    }

    void WriteSign()
    {
        if (type == multiplyKey)
        {
            numberText.text = number.ToString();
        }
        else if (type == plusKey)
        {
            numberText.text = number.ToString();
        }
    }
}
