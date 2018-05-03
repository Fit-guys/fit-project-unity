using UnityEngine;

namespace Pick
{
	public class WinLoseManager : MonoBehaviour, IWinLose
	{
		void Start()
		{
			print("1");

			//Don't touch it i know it's bad i ll fix it as soon as i can
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
