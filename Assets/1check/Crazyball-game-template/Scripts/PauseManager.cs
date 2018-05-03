﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {
	


	public static bool isPaused;		
	public GameObject pausePlane;		
	
	public enum Page { PLAY, PAUSE }
	private Page currentPage = Page.PLAY;
	
	
	void Awake() {		
		isPaused = false;
		Time.timeScale = 1.0f;
		if(pausePlane)
			pausePlane.SetActive(false); 
	}
	
	
	void Update() {


		touchManager();
		

		if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyUp(KeyCode.Escape)) {
			
			switch (currentPage) {
			case Page.PLAY: 
				PauseGame(); 
				break;
			case Page.PAUSE: 
				UnPauseGame(); 
				break;
			default: 
				currentPage = Page.PLAY; 
				break;
			}
		}
		

		if(Input.GetKeyDown(KeyCode.R)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	
	private RaycastHit hitInfo;
	private Ray ray;
	void touchManager() {
		
	    if(	Input.touches.Length > 0 && Input.touches[0].phase == TouchPhase.Ended)  
			ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
		else if(Input.GetMouseButtonUp(0))
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		else
			return;
		
		if (Physics.Raycast(ray, out hitInfo)) {
			GameObject objectHit = hitInfo.transform.gameObject;
			switch(objectHit.name) {
				case "pauseBtn":
					switch (currentPage) {
						case Page.PLAY: 
							PauseGame(); 
							break;
						case Page.PAUSE: 
							UnPauseGame(); 
							break;
						default: 
							currentPage = Page.PLAY; 
							break;
						}
					break;
					
				case "retryButtonPause":
					UnPauseGame(); 
					SceneManager.LoadScene(SceneManager.GetActiveScene().name);
					break;
					
				case "menuButtonPause":
					UnPauseGame(); 
					SceneManager.LoadScene("Menu");
					break;
			}	
		}
	}



	void PauseGame() {
		print("Game is Paused...");
		isPaused = true;
		Time.timeScale = 0;
		AudioListener.volume = 0;
		if(pausePlane)
			pausePlane.SetActive(true);
		currentPage = Page.PAUSE;
	}
	
	void UnPauseGame() {
		print("Unpause");
		isPaused = false;
		Time.timeScale = 1.0f;
		AudioListener.volume = 1.0f;
		if(pausePlane)
			pausePlane.SetActive(false);   
		currentPage = Page.PLAY;
	}

}
