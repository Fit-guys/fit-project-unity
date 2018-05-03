using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
    public bool complited = false;
    static Dictionary<string, string> gameDict = new Dictionary<string, string>
    {
         { "Quest_1" , "doodle_jump" },
         { "Quest_2" , "card_match" },
         { "Quest_3" , "puzzle_game" },
         { "Quest_4" , "Balls" }
    };
	// Use this for initialization
	void Start () {
        complited = MetaData.GetWins(gameDict[gameObject.name]);
        if(complited == true)
        {
            GetComponent<Button>().enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {

	}
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameDict[gameObject.name]);
        //TODO: Связь между играми
    }

}
