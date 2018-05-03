using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaData: MonoBehaviour {

    static Dictionary<string, bool> win = new Dictionary<string, bool>
        {
             { "card_match" , false},
             { "doodle_jump" , false},
             { "bird" , false},
             { "puzzle_game" , false},
             {"Balls", false},
             {"pick_game", false }
        }; // победа на сценах
    public static bool last = false;
    public static bool GetWins(string sceneName)
    {
        Debug.Log("Try to get wins");
        return win[sceneName];
    }
    public static void SetWins(string sceneName, bool value)
    {
        if (win.ContainsKey(sceneName))
        {
            win[sceneName] = value;
        }
        last = value;
    }
}
