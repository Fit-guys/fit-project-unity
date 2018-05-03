using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseWindow : MonoBehaviour {

    void Start()
    {
    }
    void Update()
    { 
    }
    public void Close()
    {
        transform.localScale = new Vector3(0f, 0f);
    }
    public void Open()
    {
        transform.localScale = new Vector3(1f, 1f);
    }
    public void Exit()
    {
        WinLose.fromMenu = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene("menu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
