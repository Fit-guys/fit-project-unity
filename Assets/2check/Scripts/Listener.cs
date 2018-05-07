using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Listener : MonoBehaviour {

    // Use this for initialization
    [SerializeField] GameObject main_help;
    void Start () {
        if (ChooseSubject.physics)
        {
            GameObject.Find("ZNO_3").GetComponentInChildren<Text>().text = "Фізика:";
        }
        else
        {
            GameObject.Find("ZNO_3").GetComponentInChildren<Text>().text = "Англыйська мова:";
        }
        GameObject.Find("ZNO_1").GetComponent<UnityEngine.UI.InputField>().text = Convert.ToString(ZNOResults._UkrainianScore);
        GameObject.Find("ZNO_2").GetComponent<UnityEngine.UI.InputField>().text = Convert.ToString(ZNOResults._MathsScore);
        GameObject.Find("ZNO_3").GetComponent<UnityEngine.UI.InputField>().text = Convert.ToString(ZNOResults._ThirdScore);
        Form.CheckForUpdate();
    }
	
	// Update is called once per frame
	void Update () {
    }
    public void Submit()
    {
        main_help.SetActive(true);
    }
    public void NextStep()
    {
        StepMenu.complitedSteps[2] = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene("menu");
    }
}
