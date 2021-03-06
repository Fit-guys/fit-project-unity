﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Table : MonoBehaviour
{
	public int winsToComplete = 5;

	[SerializeField] Button[] partPrefabs;
	GameObject[] gameParts;
	GameObject[] selectableParts;

	[SerializeField] RectTransform topPositions;
	[SerializeField] RectTransform bottomPositions;

	GameObject[] topParts;

	List<int> indexesLeft;
	Dictionary<int, int> topIndexes;

	int winsCount = -1;

	void Start()
	{
		SetParts();

		StartCoroutine(Load(true));
	}

	void SetParts()
	{
		int l = partPrefabs.Length;
		selectableParts = new GameObject[l];
		gameParts = new GameObject[l];
	}

	void SetValuesToDefault()
	{
		indexesLeft = Enumerable.Range(0, selectableParts.Length).ToList();
		topIndexes = new Dictionary<int, int>();
		topParts = new GameObject[topPositions.childCount];
	}

	void ConfigureParts()
	{
		for (int i = 0; i < partPrefabs.Length; i++)
		{
			gameParts[i].GetComponent<Image>().color = new Color(1, 1, 1, 0.25f);
			gameParts[i].GetComponent<Button>().enabled = false;
			selectableParts[i].GetComponent<Image>().color = new Color(1, 1, 1, 1);


			selectableParts[i].SetActive(false);
			gameParts[i].SetActive(false);
		}
	}

	IEnumerator Load(bool init)
	{
		yield return new WaitForSeconds(0.12f);

		FindObjectOfType<Timer>().ResetAndStartTimer();

		if (++winsCount == winsToComplete)
			FindObjectOfType<EndGame>().Win();

		if (init)
		{
			Transform sel = GameObject.Find("Selectable Parts").transform;
			Transform game = GameObject.Find("Game Parts").transform;

			for (int i = 0; i < partPrefabs.Length; i++)
			{
				selectableParts[i] = Instantiate(partPrefabs[i].gameObject, sel);
				gameParts[i] = Instantiate(partPrefabs[i].gameObject, game);
			}
		}

		ConfigureParts();

		SetValuesToDefault();

		Scrumble();

		//TODO:
		//Timer.ResetAndStartTimer(4);
	}

	void Scrumble()
	{
		int topCount = topPositions.childCount;
		int bottomCount = bottomPositions.childCount;

		GameObject[] bottomParts = new GameObject[bottomCount];

		for (int i = 0; i < topCount; i++)
		{
			var topPart = GetRandomPart(true);
			topParts[i] = topPart;

			topParts[i].transform.position = topPositions.GetChild(i).position;
			topParts[i].SetActive(true);
		}

		GetSameFromTop(bottomParts);

		for (int i = topCount; i < bottomCount; i++)
			bottomParts[i] = GetRandomPart(false);

		ShuffleBottomGameObjects(bottomParts);

		for (int i = 0; i < bottomParts.Length; i++)
		{
			bottomParts[i].transform.position = bottomPositions.GetChild(i).position;
			bottomParts[i].SetActive(true);
		}
	}

	void GetSameFromTop(GameObject[] bottomParts)
	{
		for (int i = 0; i < topIndexes.Count; i++)
			bottomParts[i] = selectableParts[topIndexes.FirstOrDefault(x => x.Value == i).Key];
	}

	GameObject GetRandomPart(bool top)
	{
		var num = indexesLeft[UnityEngine.Random.Range(0, indexesLeft.Count)];
		indexesLeft.Remove(num);

		if (top)
		{
			topIndexes.Add(num, topIndexes.Count);
			return gameParts[num];
		}

		return selectableParts[num];
	}

	void ShuffleBottomGameObjects(GameObject[] bot)
	{
		int l = bot.Length;
		for (int i = l; i > 1; i--)
		{
			int j = UnityEngine.Random.Range(0, l);

			GameObject tmp = bot[j];
			bot[j] = bot[i - 1];
			bot[i - 1] = tmp;
		}
	}

	public void OnPartClicked(GameObject part)
	{
		int indexOfPart = Array.IndexOf(selectableParts, part);

		part.GetComponent<Image>().color = new Color(0, 0, 0, 0);

		if (!topIndexes.ContainsKey(indexOfPart))
			OnWrongAnswer();

		else
		{
			int topButtonId = topIndexes[indexOfPart];

			topParts[topButtonId].GetComponent<Image>().color = new Color(1, 1, 1, 1);

			topIndexes.Remove(indexOfPart);

			if (topIndexes.Count == 0)
				StartCoroutine(Load(init: false));
		}
	}

	void OnWrongAnswer()
	{
		print("PartManager -- OnWrongAnswer");
	}
}
