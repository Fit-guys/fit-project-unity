using UnityEngine;

public class UIPanelsManager_2 : Singleton<UIPanelsManager_2>
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
