using UnityEngine;

namespace Pick
{
	public class WinLoseManager : MonoBehaviour, IWinLose
	{
		void Start()
		{
            Debug.Log("Start");
			//print("1");
			//MainManager.Instance.OnWin += Win;
			//MainManager.Instance.OnLose += Lose;
		}

		public void Lose()
		{
			UIPanelsManager.Instance.ShowLosePanel("pick_game");
		}

		public void Win()
		{
			UIPanelsManager.Instance.ShowWinPanel("pick_game");
		}
	}
}
