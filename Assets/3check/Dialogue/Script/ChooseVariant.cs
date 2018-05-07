using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseVariant : MonoBehaviour
{

    public string[] variants;
    int i = 1;
    void Start()
    {
        GameObject.Find("Submit").GetComponent<Button>().enabled = false;
        GetComponentInChildren<Text>().text = variants[0];
    }
    public void Next()
    {
        if (variants[i] == "")
        {
            GetComponent<Button>().enabled = false;
        }
        else
        {
            GetComponent<Button>().enabled = true;
        }
        GetComponentInChildren<Text>().text = variants[i++];

    }
    public void Click()
    {
        GameObject.Find("Submit").GetComponent<Button>().enabled = true;
        GameObject.Find("InputField").GetComponent<UnityEngine.UI.InputField>().text = GetComponentInChildren<Text>().text;
    }
}
