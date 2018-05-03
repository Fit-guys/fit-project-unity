using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {
	

	
	public static int playerScore;			
	public GameObject scoreTextDynamic;		

	void Awake() {
		playerScore = 0;								
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Application.targetFrameRate = 60;
	}
	
	
	void Update() {
		if(!GameController.gameOver)
			calculateScore();
	}
	
	

	void calculateScore() {
		if(!PauseManager.isPaused) {
			playerScore += (int)( GameController.currentLevel * Mathf.Log(GameController.currentLevel + 1, 2) );
			scoreTextDynamic.GetComponent<TextMesh>().text = playerScore.ToString();
		}
		if (playerScore > 1000) {
			print ("Game Over");
            UIPanelsManager.Instance.ShowWinPanel("Balls");
            //GameController.gameOver = true;
		}
	}



	void OnCollisionEnter(Collision c) {

		if(c.gameObject.tag == "Maze") {
			print ("Game Over");
			GameController.gameOver = true;
		}

		if(c.gameObject.tag == "enemyBall") {
			Destroy(c.gameObject);
		}
	}
	
	
	void playSfx(AudioClip _sfx) {
		GetComponent<AudioSource>().clip = _sfx;
		if(!GetComponent<AudioSource>().isPlaying)
			GetComponent<AudioSource>().Play();
	}
}
