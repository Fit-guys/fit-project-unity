using UnityEngine;

//TODO: IMPLEMENT GENERIC WINLOSEMANAGER FOR ALL GAMES
namespace PuzzleGame
{
	public class MainManager : Singleton<MainManager>
	{
		public Transform[] puzzleHolders;

		public static event System.Action OnWin = delegate { };

		static int placedPuzzleCount = 0;

		//TODO:
		public static int PlacedPuzzleCount
		{
			get { return /*shitcode*/ placedPuzzleCount; }
			set { placedPuzzleCount = value; if (value == 4) OnWin(); }
		}

		void Start()
		{
			//TODO
		}

		void PlacePuzzlesRandomly()
		{
			//TODO
		}
	}
}
