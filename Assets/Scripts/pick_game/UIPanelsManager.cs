using UnityEngine;

public class UIPanelsManager : MonoSingleton<UIPanelsManager>
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
