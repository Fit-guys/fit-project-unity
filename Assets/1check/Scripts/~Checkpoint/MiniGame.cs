using UnityEngine;

public class MiniGame : MonoBehaviour
{
	[SerializeField] string game;
    public int gameIndex;
	GameObject tip;

	void Start()
	{
		tip = transform.GetChild(1).gameObject;
	}

	public void LaunchGame()
	{
        Checkpoint.LastMiniGamePlayed = gameIndex;//this.transform.GetSiblingIndex();
		UnityEngine.SceneManagement.SceneManager.LoadScene(game);
	}

	public void ToggleTip(bool show)
	{
		tip.SetActive(show);
	}
}
