using UnityEngine;

public class Player : MonoBehaviour
{
	public float sideSpeed = 20;

	//Temp
	float pushStrength = 8f;

	Rigidbody2D rb;
	float endX;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		endX = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Platform")
		{
			//When falls down
			if (rb.velocity.y < 0)
			{
				Vector2 rbVelocity = rb.velocity;
				rbVelocity.y = pushStrength;
				rb.velocity = rbVelocity;
			}
		}
	}

	private void Update()
	{
		Move();
		SideWalk();
		CheckDeath();
	}

	private void Move()
	{
		float axis = Input.GetAxis("Horizontal");

		Vector2 velocity = rb.velocity;

		if (axis != 0)
			velocity.x = axis * sideSpeed * Time.deltaTime * 10;

		else
			velocity.x = 0;

		rb.velocity = velocity;
	}

	private void CheckDeath()
	{
		if (rb.position.y < Camera.main.ScreenToWorldPoint(Vector2.zero).y)
		{
			print("LOSE HERE!");
		}
	}

	private void SideWalk()
	{
		Vector2 pos = transform.position;

		if (rb.position.x >= endX)
			pos.x = -endX + 0.01f;

		else if (rb.position.x <= -endX)
			pos.x = endX - 0.01f;

		transform.position = pos;
	}
}
