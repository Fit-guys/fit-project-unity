﻿using UnityEngine;
using UnityEngine.UI;

public class UIPartOnClickAwakeSetter : MonoBehaviour
{
	void Awake()
	{
		GetComponent<Button>().onClick.AddListener(OnClick);	
	}

	private void OnClick()
	{
		PartManager.Instance.OnPartClicked(gameObject);
	}
}
