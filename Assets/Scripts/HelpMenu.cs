using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HelpMenu : MonoBehaviour {
    int times = 0;
    static bool isFirstTime = true;
    static bool FirstTime = true;
    int tipsShown = 0;
    [SerializeField] GameObject help;
    [SerializeField] GameObject introduction;
    [SerializeField] GameObject unblocked;
    [SerializeField] GameObject info;
    [SerializeField] GameObject blocked;
    [SerializeField] GameObject esc;
    void Start()
    {
        if (FirstTime)
        {
            help.SetActive(true);
            introduction.SetActive(true);
        }
    }

    public void ShowNextTip()
    {
        FirstTime = false;
        if (tipsShown == 0)
        {
            introduction.SetActive(false);
            unblocked.SetActive(true);
        }

        else if (tipsShown == 1)
        {
            unblocked.SetActive(false);
            info.SetActive(true);
        }

        else if (tipsShown == 2)
        {
            info.SetActive(false);
            blocked.SetActive(true);
        }
        else if (tipsShown == 3)
        {
            blocked.SetActive(false);
            esc.SetActive(true);
        }
        else if (tipsShown == 4)
        {
            esc.SetActive(false);
            help.SetActive(false);
        }

        ++tipsShown;
    }
}
