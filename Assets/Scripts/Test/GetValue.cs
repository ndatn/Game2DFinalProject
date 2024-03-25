using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetValue : MonoBehaviour
{
    [SerializeField] TMP_Text myText;
    public void LoadSceneAndKeepValue()
    {
        if (myText != null)
        {
            string dataToKeep = myText.text;
            StaticData.ValueToKeep = dataToKeep;
            SceneManager.LoadScene("Test1");
        }
        else
        {
            Debug.LogError("Text field 'myText' is not assigned in the inspector!");
        }
    }
}
