using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
	[SerializeField] float yOffset;
	GameObject player;

	void Start()
	{
		player = GameObject.Find("Player");
		yOffset = transform.position.y;
	}

	void LateUpdate()
	{
		Vector3 pos = transform.position;
		Vector2 playerPos = player.transform.position;

		float endPositionY = playerPos.y + yOffset;

		if (endPositionY > pos.y)
		{
			pos.y = endPositionY;

			transform.position = pos;
		}
	}
}