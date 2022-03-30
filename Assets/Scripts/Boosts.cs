using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Boosts : MonoBehaviour
{
    [Tooltip("Choose one Operation:" +
        "\nif you choose two options default will be multiply" + "\nIf you don't choose any option default will be Plus")]
    [SerializeField] bool Multiply;
    [SerializeField] bool Plus;
    string operation = "Multiply, Plus";

    [SerializeField] int number;
    TextMeshProUGUI numberText;


    [HideInInspector] public const string multiplyKey = "Multiply";
    [HideInInspector] public const string plusKey = "Plus";

    void Awake()
    {
        Canvas mycanvas = GetComponentInChildren<Canvas>();
        numberText = GetComponentInChildren<TextMeshProUGUI>();

    }

    void Update()
    {
        Sign();
    }

    public int GetNumber()
    {
        return number;
    }

    public string GetSign()
    { 
        return operation;
    }

    void Sign()
    {
        Plus = !Multiply;
        if (Multiply)
        {
            operation = multiplyKey;
            numberText.text = "x" + number.ToString();
        }
        else
        {
            operation = plusKey;
            numberText.text = "+" + number.ToString();
        }
    }
}
