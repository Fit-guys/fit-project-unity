using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour 
{
	public static GameControl instance;			
	public Text scoreText;						
	public GameObject gameOvertext;				

	private int score = 0;						
	public bool gameOver = false;				
	public float scrollSpeed = -1.5f;


	void Awake()
	{
		
		if (instance == null)

			instance = this;
		
		else if(instance != this)
			
			Destroy (gameObject);
	}

	void Update()
	{
		
		if (gameOver && Input.GetMouseButtonDown(0)) 
		{
			
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	public void BirdScored()
	{
		
		if (gameOver)	
			return;
		score++;
		scoreText.text = "Score: " + score.ToString();
		if (score == 7) {
			BirdDied ();
		}
	}

	public void BirdDied()
	{
		if (score == 7) {
		
		}
		gameOvertext.SetActive (true);

		gameOver = true;
	}
}
