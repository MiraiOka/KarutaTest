using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.SerializableAttribute]
public class Karuta : MonoBehaviour
{
    public string text;
    public string hiragana;

    public void SetFromCSV(string[] data)
    {
        text = data[0];
        hiragana = data[1];
    }
}
