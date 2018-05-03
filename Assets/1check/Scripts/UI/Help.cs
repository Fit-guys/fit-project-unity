using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help : MonoBehaviour {
    int times = 0;
    static bool isFirstTime = true;
	// Use this for initialization
	void Start () {
        if (isFirstTime)
        {
            GameObject.Find("DarkImage").GetComponent<RectTransform>().transform.localScale = new Vector2(1,1);
            //GameObject.Find("DarkImage").SetActive(false);
            //GameObject.Find("QuestHelp").transform.localScale = new Vector2(103.7124f, 103.7124f);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Next()
    {
        switch (times)
        {
            case 0:
                GameObject.Find("QuestHelp").transform.localScale = new Vector2(0, 0);
                GameObject.Find("CompHelp").transform.localScale = new Vector2(105.1193f, 105.1193f);
                break;
            case 1:
                GameObject.Find("CompHelp").transform.localScale = new Vector2(0, 0);
                GameObject.Find("PauseHelp").transform.localScale = new Vector2(103.712f, 103.712f);
                break;
            case 2:
                GameObject.Find("PauseHelp").transform.localScale = new Vector2(0, 0);
                GameObject.Find("DarkImage").GetComponent<RectTransform>().transform.localScale = new Vector2(0, 0);
                isFirstTime = false;
                break;
        }
        times++;
    }
}
