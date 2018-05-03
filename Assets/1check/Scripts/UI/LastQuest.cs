using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastQuest : MonoBehaviour {

    bool isReady = true;
	// Use this for initialization
	void Start () {
        GameObject[] quests = new GameObject[4];
        for (int i = 1; i <= 4; i++)
        {
            string name = "Quest_" + i;
            quests[i-1] = GameObject.Find(name);
            isReady &= quests[i-1].GetComponent<Game>().complited;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Enter()
    {
        if (!isReady)
        {
            GameObject.Find("Hint").GetComponent<Transform>().transform.localScale = new Vector2(1, 1);
        }
    }
    public void Exit()
    {
        if (!isReady)
        {
            GameObject.Find("Hint").GetComponent<Transform>().transform.localScale = new Vector2(0, 0);
        }
    }
    public void Click()
    {
        if (isReady)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("pick_game");
        }
    }
}
