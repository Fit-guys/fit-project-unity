using UnityEngine;

public class WinLoseManager : MonoBehaviour
{
	void Start()
	{
		TimeManager.Instance.OnLose += Lose;
	}

	public void Lose()
	{
		UIPanelsManager.Instance.ShowLosePanel();
	}

	public void Win()
	{
		UIPanelsManager.Instance.ShowWinPanel();
	}
}
