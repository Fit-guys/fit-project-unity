using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSubject : MonoBehaviour {

    public static bool physics = true;
    public void Click()
    {
        if(gameObject.name == "English")
            physics = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("menu_zno");
    }
}
