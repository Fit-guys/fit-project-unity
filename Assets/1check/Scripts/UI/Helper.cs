using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour {

	// Use this for initialization
	void Start () {
        for (int i = 1; i <= 4; i++)
        {
            GameObject.Find("Clue_" + i).GetComponent<Transform>().transform.localScale = new Vector2(0, 0);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Click_1()
    {
        GameObject.Find("Clue_1").GetComponent<Transform>().transform.localScale = new Vector2(1, 1);
    }
    public void Click_2()
    {
        GameObject.Find("Clue_2").GetComponent<Transform>().transform.localScale = new Vector2(1, 1);
    }
    public void Click_3()
    {
        GameObject.Find("Clue_3").GetComponent<Transform>().transform.localScale = new Vector2(1, 1);
    }
    public void Click_4()
    {
        GameObject.Find("Clue_4").GetComponent<Transform>().transform.localScale = new Vector2(1, 1);
    }
}
