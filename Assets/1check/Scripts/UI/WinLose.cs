using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour {

    static bool isShow = false;
    public static bool fromMenu = true;
    // Use this for initialization
    void Start()
    {
        Debug.Log("isShow" + isShow);
        if (isShow && !fromMenu)
        {
            if (MetaData.last)
            {
                GameObject.Find("Win").GetComponent<RectTransform>().transform.localScale = new Vector2(1, 1);
            }
            else
                GameObject.Find("Lose").GetComponent<RectTransform>().transform.localScale = new Vector2(1, 1);
        }
        fromMenu = false;
        isShow = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click()
    {
        GameObject.Find("Lose").GetComponent<RectTransform>().transform.localScale = new Vector2(0, 0);
        GameObject.Find("Win").GetComponent<RectTransform>().transform.localScale = new Vector2(0, 0);
    }
}
