using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Form : MonoBehaviour {
    [SerializeField] Text hint;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
    }
    //Check field for empty
    bool isEmpty()
    {
        Debug.Log(gameObject.GetComponentInChildren<Text>().text);
        if(gameObject.GetComponentInChildren<Text>().text.Length == 0)
        {
            Registration.isValid[gameObject.name] = false;
            return true;
        }
        Registration.isValid[gameObject.name] = true;
        return false;
    }
    //Hint become empty
    public void OnChange()
    {
        hint.text = "";
    }
    public void Validation()
    {
        if (isEmpty())
        {
            hint.text = "Поле повинно бути заповненым";
        }
        CheckForUpdate();
    }
    //Check field with numbers for correct value
    public void NumberValidation()
    {
        if(isEmpty())
            hint.text = "Поле повинно бути заповненым";
        int number = 0;
        switch (gameObject.name)
        {
            case "PhoneNumber" :
                number = 10;
                break;
            case "CertificateNumber":
                number = 7;
                break;
            case "Pin":
                number = 4;
                break;
            case "SchoolCertificateNumber":
                number = 6;
                break;
        }
        if (gameObject.GetComponentInChildren<Text>().text.Length < number && gameObject.GetComponentInChildren<Text>().text.Length > 0)
        {
            Registration.isValid[gameObject.name] = false;
            hint.text = "Поле має містити " + number + " цифр";
        }
        CheckForUpdate();
    }
    //Check SchoolMark field with numbers for correct value
    public void MarkValidation()
    {
        if(isEmpty())
            hint.text = "Поле повинно бути заповненым";
        else if (Convert.ToDouble(gameObject.GetComponentInChildren<Text>().text) > 12 || Convert.ToDouble(gameObject.GetComponentInChildren<Text>().text) < 0)
        {
            Registration.isValid[gameObject.name] = false;
            hint.text = "Некоректна оцінка";
        }
        CheckForUpdate();
    }
    // First part of CertificateNumber must be in uppercase
    public void OnSchoolCertificateNumberChange()
    {
        string text = GameObject.Find(gameObject.name).GetComponent<UnityEngine.UI.InputField>().text;
        for (int i = 48; i < 58; i++)
        {
            if (text.Length > 0 && text[text.Length - 1] == i)
            {
                text = text.Remove(text.Length - 1);
            }
        }
        GameObject.Find(gameObject.name).GetComponent<UnityEngine.UI.InputField>().text = text.ToUpperInvariant();
    }
    // Check email field for correct format
    public void EmailValidate()
    {
        string text = gameObject.GetComponentInChildren<Text>().text;
        if (isEmpty())
        {
            hint.text = "Поле повинно бути заповненым";
        }
        else if (text.Contains("@"))
        {
            if (text.Contains(".") && text.LastIndexOf('.') > text.IndexOf('@')+1 && text.LastIndexOf('.') < text.Length-1)
            {
                hint.text = "";
            }
            else
            {
                hint.text = "Email має невірний фоормат";
                Registration.isValid[gameObject.name] = false;
            }
        }
        else
        {
            hint.text = "Email має невірний фоормат";
            Registration.isValid[gameObject.name] = false;
        }
        CheckForUpdate();
    }
    public void Understand()
    {
        Registration.isValid[gameObject.name] = gameObject.GetComponent<Toggle>().isOn;
        CheckForUpdate();
    }
    //Check form for valid data in even field
    public static void CheckForUpdate()
    {
        bool valid = true;
        foreach (var pare in Registration.isValid)
        {
            valid &= pare.Value;
        }
        if (valid)
            GameObject.Find("Submit").GetComponent<Button>().enabled = true;
        else
            GameObject.Find("Submit").GetComponent<Button>().enabled = false;
    }
    public void ShowZNO()
    {
        GameObject.Find("score").GetComponent<UnityEngine.UI.InputField>().text = Convert.ToString(
        (double)ZNOResults._UkrainianScore * 0.2 + ZNOResults._MathsScore * 0.6 + ZNOResults._ThirdScore * 0.2);
    }
}
