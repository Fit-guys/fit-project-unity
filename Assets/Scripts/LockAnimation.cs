using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class LockAnimation : MonoBehaviour{
    Vector3 startPosition;
	// Use this for initialization
	void Start () {
        Transform tr = gameObject.GetComponent<Transform>();
        startPosition = tr.position;
	}
    // Update is called once per frame
    void Update () {
     
	}
    public void On()
    {
        gameObject.GetComponent<Animator>().enabled = true;
        
    }
    public void Exit()
    {
        gameObject.GetComponent<Animator>().enabled = false;
        transform.position = startPosition;
    }
}
