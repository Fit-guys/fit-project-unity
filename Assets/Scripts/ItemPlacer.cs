using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ItemPlacer : MonoBehaviour
{
	[SerializeField] Button[] partPrefabs;
	GameObject[] gameParts;
	GameObject[] selectableParts;

	[SerializeField] RectTransform topPositions;
	[SerializeField] RectTransform bottomPositions;

	List<int> indexesLeft;
	List<int> topIndexes;

	void Start()
	{
		int l = partPrefabs.Length;

		Transform sel = GameObject.Find("Selectable Parts").transform;
		Transform game = GameObject.Find("Game Parts").transform;

		selectableParts = new GameObject[l];
		gameParts = new GameObject[l];

		for (int i = 0; i < l; i++)
		{
			selectableParts[i] = Instantiate(partPrefabs[i].gameObject, sel);
			gameParts[i] = Instantiate(partPrefabs[i].gameObject, game);

			selectableParts[i].SetActive(false);
			gameParts[i].SetActive(false);

			gameParts[i].GetComponent<Image>().color = new Color(1, 1, 1, 0.25f);
		}

		PlaceItems();
	}

	void Reset()
	{
		indexesLeft = Enumerable.Range(0, selectableParts.Length).ToList();
		topIndexes = new List<int>();
	}

	void PlaceItems()
	{
		Reset();

		int topCount = topPositions.childCount;
		int bottomCount = bottomPositions.childCount;

		GameObject[] topParts = new GameObject[topCount];
		GameObject[] bottomParts = new GameObject[bottomCount];

		for (int i = 0; i < topCount; i++)
		{
			var topPart = GetRandomPart(true);
			topParts[i] = topPart;

			//Placement
			topParts[i].transform.position = topPositions.GetChild(i).position;
			topParts[i].SetActive(true);
		}

		GetSameFromTop(bottomParts);

		for (int i = topCount; i < bottomCount; i++)
			bottomParts[i] = GetRandomPart(false);

		Shuffle(bottomParts);

		//Bottom placement
		for (int i = 0; i < bottomParts.Length; i++)
		{
			bottomParts[i].transform.position = bottomPositions.GetChild(i).position;
			bottomParts[i].SetActive(true);
		}
	}

	void GetSameFromTop(GameObject[] bottomParts)
	{
		for (int i = 0; i < topIndexes.Count; i++)
			bottomParts[i] = selectableParts[topIndexes[i]];
	}

	GameObject GetRandomPart(bool top)
	{
		var num = indexesLeft[Random.Range(0, indexesLeft.Count)];
		indexesLeft.Remove(num);

		if (top)
		{
			topIndexes.Add(num);
			return gameParts[num];
		}

		return selectableParts[num];
	}

	void Shuffle(GameObject[] bot)
	{
		int l = bot.Length;
		for (int i = l; i > 1; i--)
		{
			int j = Random.Range(0, l);

			GameObject tmp = bot[j];
			bot[j] = bot[i - 1];
			bot[i - 1] = tmp;
		}
	}
}
