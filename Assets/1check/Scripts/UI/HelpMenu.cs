using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HelpMenu : MonoBehaviour {
    int times = 0;
    static bool isFirstTime = true;
    // Use this for initialization
    void Start()
    {
        Debug.Log(isFirstTime);
        if (isFirstTime)
        {
            GameObject.Find("Animation").transform.localScale = new Vector2(94.34799f, 103.7707f);
            GameObject.Find("darkImage").GetComponent<RectTransform>().transform.localScale = new Vector2(1, 1);
            GameObject.Find("Understand").transform.localScale = new Vector2(1, 1);
            //GameObject.Find("DarkImage").SetActive(false);
            //GameObject.Find("QuestHelp").transform.localScale = new Vector2(103.7124f, 103.7124f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Next()
    {
        Debug.Log("11");
        switch (times)
        {
            case 0:
                GameObject.Find("Animation").transform.localScale = new Vector2(0, 0);
                GameObject.Find("Do").transform.localScale = new Vector2(94.34799f, 103.7707f);
                break;
            case 1:
                GameObject.Find("Do").transform.localScale = new Vector2(0, 0);
                GameObject.Find("Lock").transform.localScale = new Vector2(94.34799f, 103.7707f);
                break;
            case 2:
                GameObject.Find("Lock").transform.localScale = new Vector2(0, 0);
                GameObject.Find("Pause").transform.localScale = new Vector2(115.204f, 122.2398f);
                break;
            case 3:
                GameObject.Find("Pause").transform.localScale = new Vector2(0, 0);
                GameObject.Find("darkImage").GetComponent<RectTransform>().transform.localScale = new Vector2(0, 0);
                foreach (var item in GameObject.Find("Background").GetComponentsInChildren<Button>())
                {
                    item.interactable = true;
                }
                GameObject.Find("Understand").transform.localScale = new Vector2(0, 0);
                isFirstTime = false;
                break;
        }
        times++;
    }
}
