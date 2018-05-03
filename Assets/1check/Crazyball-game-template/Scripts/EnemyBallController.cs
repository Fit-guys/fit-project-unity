using UnityEngine;
using System.Collections;

public class EnemyBallController : MonoBehaviour {


	
	private float speed;							
	private float destroyThreshold = -6.5f;		
	
	void Start() {
		
		speed = Random.Range(0.6f, 2.0f);
	}

	void Update() {
		
		transform.position -= new Vector3(0, 0, Time.deltaTime * 
		                                 		GameController.moveSpeed * 
		                                 		speed);
		
		if (transform.position.z < destroyThreshold) {
			GameController.gameOver = true;
			Destroy(gameObject);
		}
	}
}
