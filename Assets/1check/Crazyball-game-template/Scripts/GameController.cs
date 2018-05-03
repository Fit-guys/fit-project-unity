using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	

	static int gameMode = 0; 				

	public static float moveSpeed; 			
	public static float cloneInterval; 		
	

	public static int currentLevel = 1;		
	private float levelJump = 10.0f; 		

	private Vector3 startPoint;				
	private float levelPassedTime;		
	private float levelStartTime;			
	

	public static bool gameOver;			
	private bool gameOverFlag;				
	

	public AudioClip levelAdvanceSfx;
	public AudioClip gameoverSfx;
	

	private bool createMaze;				
	private bool createEnemyBall;			


	public GameObject[] maze;				
	public GameObject enemyBall;			
	

	public GameObject gameOverPlane;		
	public GameObject mainBackground;		
	public GameObject player;				
	
	

	void Awake() {

		gameOverPlane.SetActive(false);				
		mainBackground.GetComponent<Renderer>().material.color = new Color(1, 1, 1);	
		gameMode = PlayerPrefs.GetInt("GameMode");	

		createMaze = true;			
		createEnemyBall = true;		

		currentLevel = 1;				
		levelPassedTime = 0;
		levelStartTime = 0;
		moveSpeed = 1.2f;
		cloneInterval = 1.0f;
		gameOver = false;
		gameOverFlag = false;
	}
	
	
	///***********************************************************************
	/// Main FSM
	///***********************************************************************
	void Update() {

		//If we have lost the set
		if(gameOver) {

			if(!gameOverFlag) {
				gameOverFlag = true;
                UIPanelsManager.Instance.ShowLosePanel("Balls");
                playSfx(gameoverSfx);
				////show gameover menu
				//processGameover();
			}

			return;
		}

		//Escape or Survival modes ?
		if(gameMode == 0) {
			//if we are allowed to spawn a maze
			if(createMaze) 
				cloneMaze(); 
		} else {
			//if we are allowed to spawn enemyBall
			if(createEnemyBall) 
				cloneEnemyBall();
		}
		
		//if the game is not yet finished, make it harder and harder by increasing the objects movement speed
		modifyLevelDifficulty();
		
	}
	
	///***********************************************************************
	/// Clone Maze item based on a simple chance factor
	///***********************************************************************
	void cloneMaze() {
		createMaze = false;
		startPoint = new Vector3( Random.Range(-1.0f, 1.0f) , 0.5f, 7);
		Instantiate(maze[Random.Range(0, maze.Length)], startPoint, Quaternion.Euler( new Vector3(0, 0, 0)));	
		StartCoroutine(reactiveMazeCreation());
	}


	///***********************************************************************
	/// Clone a new enemyball object and let them have random sizes
	///***********************************************************************
	void cloneEnemyBall() {
		createEnemyBall = false;
		startPoint = new Vector3( Random.Range(-3.2f, 3.2f) , 0.5f, 7);
		GameObject eb = Instantiate(enemyBall, startPoint, Quaternion.Euler( new Vector3(0, 0, 0))) as GameObject;	
		eb.name = "enemyBall";
		float scaleModifier = Random.Range(-0.4f, 0.1f);
		eb.transform.localScale = new Vector3(eb.transform.localScale.x + scaleModifier,
		                                      eb.transform.localScale.y,
		                                      eb.transform.localScale.z + scaleModifier);
		StartCoroutine(reactiveEnemyBallCreation());
	}


	//enable this controller to be able to clone maze objects again
	IEnumerator reactiveMazeCreation() {
		yield return new WaitForSeconds(cloneInterval);
		createMaze = true;
	}


	//enable this controller to be able to clone enemyball objects again
	IEnumerator reactiveEnemyBallCreation() {
		yield return new WaitForSeconds(0.35f);
		createEnemyBall = true;
	}
	
	
	///***********************************************************************
	/// Here can increase gameSpeed and decrease itemCloneInterval values to 
	/// make the game harder.
	///***********************************************************************
	void modifyLevelDifficulty() {

		levelPassedTime = Time.timeSinceLevelLoad;
		if(levelPassedTime > levelStartTime + levelJump) {

			//increase level difficulty (but limit it to a maximum level of 10)
			if(currentLevel < 10) {

				currentLevel += 1;

				//let the player know what happened to him/her
				playSfx(levelAdvanceSfx);

				//increase difficulty by increasing movement speed
				moveSpeed += 0.6f;

				//clone items faster
				cloneInterval -= 0.18f; //very important!!!
				print ("cloneInterval: " + cloneInterval);
				if(cloneInterval < 0.3f) cloneInterval = 0.3f;

				levelStartTime += levelJump;

				//Background color correction (fade to red)
				float colorCorrection = currentLevel / 10.0f;
				//print("colorCorrection: " + colorCorrection);
				mainBackground.GetComponent<Renderer>().material.color = new Color(1, 
								                                                   1 - colorCorrection, 
								                                                   1 - colorCorrection);
			}
		}
	}
	
	
	///***********************************************************************
	/// Game Over routine
	///***********************************************************************
	void processGameover() {
		gameOverPlane.SetActive(true);
	}


	///***********************************************************************
	/// Play audioclips
	///***********************************************************************
	void playSfx(AudioClip _sfx) {
		GetComponent<AudioSource>().clip = _sfx;
		if(!GetComponent<AudioSource>().isPlaying)
			GetComponent<AudioSource>().Play();
	}	

}