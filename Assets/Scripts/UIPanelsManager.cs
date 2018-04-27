using UnityEngine;

public class UIPanelsManager : Singleton<UIPanelsManager>
{
	[SerializeField] GameObject losePanel;
	[SerializeField] GameObject winPanel;

	public void ShowLosePanel()
	{
		losePanel.SetActive(true);
	}

	public void ShowWinPanel()
	{
		winPanel.SetActive(true);
	}
}
