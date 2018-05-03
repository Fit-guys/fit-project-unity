using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confirmed : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Transform>().transform.localScale = new Vector2(0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.Find("Quest_" + gameObject.name[gameObject.name.Length - 1]).GetComponent<Game>().complited)
        {
            gameObject.GetComponent<Transform>().transform.localScale = new Vector2(1, 1);
        }
	}
}
