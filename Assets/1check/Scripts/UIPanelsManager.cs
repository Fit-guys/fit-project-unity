using UnityEngine;

public class UIPanelsManager : Singleton<UIPanelsManager>
{
	[SerializeField] GameObject loseMenu;
	[SerializeField] GameObject winMenu;

	[SerializeField] GameObject blockingPanel;

	public void ShowLosePanel(string sceneName)
	{
		//blockingPanel.SetActive(true);
		//loseMenu.SetActive(true);
        UnityEngine.SceneManagement.SceneManager.LoadScene("1check");
        MetaData.SetWins(sceneName, false);

    }

	public void ShowWinPanel(string sceneName)
	{
        //blockingPanel.SetActive(true);
        //winMenu.SetActive(true);
        Debug.Log("Win");
        UnityEngine.SceneManagement.SceneManager.LoadScene("1check");
        MetaData.SetWins(sceneName, true);
    }
}
