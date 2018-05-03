using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: IMPLEMENT GENERIC VERSION OF THIS PIECE OF CRAP 
namespace PuzzleGame
{

	//TODO: FIX THE POSSIBILITY TO WIN AND LOSE AT ONCE





	public class WinLoseManager : MonoBehaviour, IWinLose
	{
		void Start()
		{
			print("1");
			MainManager.OnWin += Win;
			TimeManager.Instance.OnLose += Lose;
		}

		public void Lose()
		{
<<<<<<< HEAD
			UIPanelsManager.Instance.ShowLosePanel("puzzle_game");
=======
			UIPanelsManager.Instance.ShowLosePanel();
>>>>>>> 33241823324bf11bf84d9f6c4509f324a7202c5b
		}

		public void Win()
		{
<<<<<<< HEAD
			UIPanelsManager.Instance.ShowWinPanel("puzzle_game");
=======
			UIPanelsManager.Instance.ShowWinPanel();
>>>>>>> 33241823324bf11bf84d9f6c4509f324a7202c5b
		}
	}
}
