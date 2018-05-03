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
			UIPanelsManager.Instance.ShowLosePanel("puzzle_game");
		}

		public void Win()
		{
			UIPanelsManager.Instance.ShowWinPanel("puzzle_game");
		}
	}
}
