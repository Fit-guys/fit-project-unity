using UnityEngine;

public class UIPanelsManager : Singleton<UIPanelsManager>
{
	[SerializeField] GameObject loseMenu;
	[SerializeField] GameObject winMenu;

	[SerializeField] GameObject blockingPanel;

	public void ShowLosePanel()
	{
		blockingPanel.SetActive(true);
		loseMenu.SetActive(true);
	}

	public void ShowWinPanel()
	{
		blockingPanel.SetActive(true);
		winMenu.SetActive(true);
	}
}
