using UnityEngine;
using UnityEngine.UI;

namespace Pick
{
	public class UIPartOnClickAwakeSetter : MonoBehaviour
	{
		void Awake()
		{
			GetComponent<Button>().onClick.AddListener(OnClick);
		}

		private void OnClick()
		{
			MainManager.Instance.OnPartClicked(gameObject);
		}
	} 
}
