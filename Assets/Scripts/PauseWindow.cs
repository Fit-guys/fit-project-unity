using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseWindow : MonoBehaviour {
    [SerializeField] GameObject pauseImage;
    void Start()
    {
    }
    void Update()
    {
        if (Input.GetKey("escape"))
            Open();
    }
    public void Close()
    {
        pauseImage.SetActive(false);
    }
    public void Open()
    {
        pauseImage.SetActive(true);
    }
    public void Exit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("menu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
