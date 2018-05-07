using UnityEngine;
using UnityEngine.UI;

public class UIPartOnClickAwakeSetter : MonoBehaviour
{
	void Awake()
	{
		GetComponent<Button>().onClick.AddListener(() => FindObjectOfType<Table>().OnPartClicked(gameObject));
	}
}
