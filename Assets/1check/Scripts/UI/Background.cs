using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour {

	// Use this for initialization
	void Start () {
       // GetDark();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void GetDark()
    {
        GameObject.Find("darkImage").GetComponent<RectTransform>().transform.localScale = new Vector2(1, 1);
        foreach (var item in GameObject.Find("Background").GetComponentsInChildren<Button>())
        {
            item.interactable = false;
        }
    }
    public void GetLight()
    {
        GameObject.Find("darkImage").GetComponent<RectTransform>().transform.localScale = new Vector2(0, 0);
        foreach (var item in GameObject.Find("Background").GetComponentsInChildren<Button>())
        {
            item.interactable = true;
        }
    }
}
