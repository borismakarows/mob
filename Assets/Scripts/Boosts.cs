using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boosts : MonoBehaviour
{
    [SerializeField]  string type;
    [SerializeField]  int number;

    public int GetNumber()
    {
        return number;
    }

    public string GetSign()
    {
        return type;
    }
}
