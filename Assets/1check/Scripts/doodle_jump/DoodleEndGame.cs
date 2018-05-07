using UnityEngine;

public class DoodleEndGame : EndGame
{
	void Start()
	{
		Player.OnFall += Lose;
	}

	public override void Lose()
	{
		Camera cam = Camera.main;
		cam.GetComponent<CameraFollowPlayer>().enabled = false;

		float y = cam.transform.position.y - -cam.ScreenToWorldPoint(Vector2.zero).y * 2;
		cam.transform.position = new Vector3(0, y, -10f);

		base.Lose();
	}
}
