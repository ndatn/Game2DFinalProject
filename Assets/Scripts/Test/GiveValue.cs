using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GiveValue : MonoBehaviour
{
    [SerializeField] TMP_Text myText;
    public void Start()
    {
        string newText = StaticData.ValueToKeep;
        myText.text = newText;
    }
}
