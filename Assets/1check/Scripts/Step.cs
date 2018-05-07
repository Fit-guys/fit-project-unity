using UnityEngine;

public class Step : MonoBehaviour
{
    public void Click()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("checkpoint");
    }
}
