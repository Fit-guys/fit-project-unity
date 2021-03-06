﻿using UnityEngine;

public class Player : MonoBehaviour
{
	public float sideSpeed = 80f;

	float pushStrength = 8f;

	Rigidbody2D rb;
	float endX;
	bool alreadyDead = false;

	public static event System.Action OnFall = delegate { };

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		endX = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
	}

	void OnTriggerEnter2D(Collider2D collision)
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

	void Update()
	{
		CheckDeath();
	}

	void FixedUpdate()
	{
		HandleMovement();
	}

	void HandleMovement()
	{
		float axis = Input.GetAxis("Horizontal");
		Vector2 velocity = rb.velocity;

		velocity.x = axis * sideSpeed * Time.deltaTime * 10;
		rb.velocity = velocity;

		Vector2 pos = transform.position;

		if (rb.position.x >= endX)
			pos.x = -endX + 0.01f;

		else if (rb.position.x <= -endX)
			pos.x = endX - 0.01f;

		transform.position = pos;
	}

	void CheckDeath()
	{
		if (rb.position.y < Camera.main.ScreenToWorldPoint(Vector2.zero).y && !alreadyDead)
		{
			alreadyDead = true;
			OnFall();
		}
	}
}
