using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HelpZNO_2 : MonoBehaviour
{
    [SerializeField] CanvasGroup ukrainianTip;
    int times = 0;
    static bool FirstTime = true;
    int tipsShown = 1;
    [SerializeField] GameObject[] helpers;
    void Start()
    {
        if (FirstTime)
        {
            helpers[0].SetActive(true);
            helpers[1].SetActive(true);
        }
    }

    public void ShowNextTip()
    {
        FirstTime = false;
        if (tipsShown == helpers.Length - 1)
        {
            helpers[0].SetActive(false);
        }
        else
        {
            helpers[tipsShown].SetActive(false);
            helpers[tipsShown + 1].SetActive(true);
        }

        if (tipsShown == 1)
            ukrainianTip.GetComponentInParent<EventTrigger>().OnPointerEnter(null);

        if (tipsShown == 2)
            ukrainianTip.GetComponentInParent<EventTrigger>().OnPointerExit(null);

            ++tipsShown;
    }
}
