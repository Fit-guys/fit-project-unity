using UnityEngine;

public class WinLoseManager : MonoBehaviour
{
	void Start()
	{
		TimeManager.Instance.OnLose += Lose;
	}

	public void Lose()
	{
		UIPanelsManager.Instance.ShowLosePanel("card_match");
	}

	public void Win()
	{
		UIPanelsManager.Instance.ShowWinPanel("card_match");
	}
}
