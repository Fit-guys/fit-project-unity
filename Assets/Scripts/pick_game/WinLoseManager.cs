using UnityEngine;

namespace Pick
{
	public class WinLoseManager : MonoBehaviour, IWinLose
	{
		void Start()
		{
			print("1");
			MainManager.Instance.OnWin += Win;
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
}
