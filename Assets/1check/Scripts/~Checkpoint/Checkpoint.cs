using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public enum LastGameEnd
{
	None,
	Lose,
	Win
}

public class Checkpoint : MonoBehaviour
{
	//[SerializeField] GameObject loseImage;
	//[SerializeField] GameObject winImage;
    //Changed in 22:00, help me 
    [SerializeField] GameObject comp;
    [SerializeField] GameObject buttonsParent;
    [SerializeField] GameObject complete;
    public static bool[] MiniGameWins = new bool[4];
	public static int LastMiniGamePlayed = -1;
	public static LastGameEnd LastGame = LastGameEnd.None;

	public Checkpoint()
	{
        //MiniGameWins = new bool[4];
	}

	void Start()
	{
        if (LastGame == LastGameEnd.None)
			return;
        comp.GetComponentInChildren<Text>().text = LastGame == LastGameEnd.Lose ? "Ви програли. Спробуйте ще!" : "Ви виграли! Вітаємо!";
		if (LastGame != LastGameEnd.Lose)
			MiniGameWins[LastMiniGamePlayed] = true;
        bool complited = true;
        for (int i = 0; i < 4; i++)
        {
            if(MiniGameWins[i])
            {
                buttonsParent.transform.GetChild(i).GetComponent<EventTrigger>().enabled = false;
                buttonsParent.transform.GetChild(i).GetComponentInChildren<Text>().text = "Міні гру\nпройдено";
                buttonsParent.transform.GetChild(i).GetComponentInChildren<Text>().fontSize = 22;
            }
            complited &= MiniGameWins[i];
        }
        if (complited)
        {
            Debug.Log("Win");
            complete.SetActive(true);
            StepMenu.complitedSteps[1] = true;
        }

    }
    public void BackToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("menu");
    }
}
