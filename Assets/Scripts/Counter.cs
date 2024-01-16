using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;

    public int Count = 0;

    public void Start()
    { 
        Count = 0;
    }

    public void ChickenCounter()
    {
        Count += 1;
        CounterText.text = "Count : " + Count;
    }
}
