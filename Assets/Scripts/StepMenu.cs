using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepMenu : MonoBehaviour {
    public string scene;
    public int index;
    public static bool[] complitedSteps = { true, false, false, false };
	// Use this for initialization
	void Start () {
        if (!complitedSteps[index])
        {
            GetComponent<Button>().enabled = false;
            transform.GetChild(0).GetComponent<Image>().enabled = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NextStep()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
}
