using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour 
{
	bool gameEnded = false;

	public virtual void Win()
	{
		if (!gameEnded)
			_EndGame(true);
	}

	public virtual void Lose()
	{
		if (!gameEnded)
			_EndGame(false);
	}

	void _EndGame(bool win)
	{
		Checkpoint.LastGame = win ? LastGameEnd.Win : LastGameEnd.Lose;

		SceneManager.LoadScene("Checkpoint");

		gameEnded = true;
	}
}
