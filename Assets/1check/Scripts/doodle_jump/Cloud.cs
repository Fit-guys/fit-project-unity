using UnityEngine;

public class Cloud : MonoBehaviour
{
	const float MIN_SCALE = 0.1f;
	const float MAX_SCALE = 0.5f;

	const float MIN_MOVESPEED = 0.17f;
	const float MAX_MOVESPEED = 0.3f;

	const float START_POS_X = 9;
	const float END_POS_X = -12f;

	const float MIN_POS_Y = 1f;
	const float MAX_POSITION_Y = 3.4f;

	float moveSpeed;

	void Start()
	{
		float scale = Random.Range(MIN_SCALE, MAX_SCALE);
		transform.localScale = new Vector3(scale, scale, 1);

		transform.localPosition = new Vector2(Random.Range(START_POS_X, END_POS_X), Random.Range(MIN_POS_Y, MAX_POSITION_Y));

		moveSpeed = Random.Range(MIN_MOVESPEED, MAX_MOVESPEED);
	}

	void FixedUpdate()
	{
		transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);

		if (transform.position.x < END_POS_X)
		{
			Vector3 pos = transform.position;
			pos.x = START_POS_X;

			transform.position = pos;
		}
	}
}
