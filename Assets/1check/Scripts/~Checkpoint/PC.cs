using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PC : MonoBehaviour
{
	[SerializeField] Text hint;

	bool Unlocked { get { return Checkpoint.MiniGameWins.All(x => x); } }
    //Changed with best wishes
	//public void OnMouseEntered()
	//{
	//	if (!Unlocked)
	//		hint.enabled = true;
	//}

	public void OnClicked()
	{
        hint.enabled = false;
    }

	public void OnMouseExited()
	{
	}
}
