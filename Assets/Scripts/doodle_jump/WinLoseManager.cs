using UnityEngine;

namespace Doodle
{
	public class WinLoseManager : Singleton<WinLoseManager>, IWinLose
	{
		void Start()
		{
			Player.OnLose += Lose;
		}

		public void Win()
		{

		}

		public void Lose()
		{
			Camera cam = Camera.main;
			cam.GetComponent<CameraFollowPlayer>().enabled = false;
			Transform t = cam.transform;

			float y = t.position.y - PlatformManager.Instance.HalfScreenHeight * 2;
			t.position = new Vector3(0, y, -10f);

			//Play lose sound!

			//Display UI
			//UIPanelsManager.Instance.ShowLosePanel();
		}
	}
}