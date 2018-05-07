using UnityEngine;
using UnityEngine.UI;
//TODO: Set up generic tip system
public class Tips : MonoBehaviour
{
	static bool FirstTime = true;
	int tipsShown = 0;
    [SerializeField] GameObject help;
    [SerializeField] GameObject main_help;
    [SerializeField] GameObject start_game;
    [SerializeField] GameObject results;
    [SerializeField] GameObject comp;
    [SerializeField] GameObject esc;
    [SerializeField] GameObject rules;
    [SerializeField] GameObject tip;
    [SerializeField] GameObject understand;
    void Start()
	{
		if (FirstTime)
		{
            help.SetActive(true);
            main_help.SetActive(true);
		}
	}

	public void ShowNextTip()
	{
        FirstTime = false;
        if (tipsShown == 0)
		{
            main_help.SetActive(false);
            start_game.SetActive(true);
        }

		else if (tipsShown == 1)
		{
            start_game.SetActive(false);
            results.SetActive(true);
            comp.GetComponentInChildren<Text>().text = "Ви вийграли! Вітаємо";
        }

		else if (tipsShown == 2)
		{
            results.SetActive(false);
            comp.GetComponentInChildren<Text>().text = "";
            esc.SetActive(true);
        }
        else if (tipsShown == 3)
        {
            esc.SetActive(false);
            tip.SetActive(true);
            rules.SetActive(true);
        }
        else if (tipsShown == 4)
        {
            rules.SetActive(false);
            tip.SetActive(false);
            understand.SetActive(false);
            help.SetActive(false);
        }

        ++tipsShown;
	}
}
