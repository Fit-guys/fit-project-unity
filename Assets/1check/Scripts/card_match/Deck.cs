using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
	[SerializeField] Sprite[] cardSprites;
	[SerializeField] Sprite cardBack;

	Image[] cards;
	Button[] cards_ButtonComponents;

	int cardsTotalAmount;
	int cardsCollected = 0;

	Dictionary<int, int> cardValues;

	int firstSelectedCardIndex = -1;

	void Start()
	{
		FindCards();

		AssignCardValues();
	}

	int[] GetRandomValues(int amount)
	{
		int[] r = new int[amount];
		List<int> valuesLeft = Enumerable.Range(0, cardSprites.Length).ToList();

		for (int i = 0; i < amount; i++)
		{
			int index = Random.Range(0, valuesLeft.Count);
			r[i] = valuesLeft[index];

			valuesLeft.RemoveAt(index);
		}

		return r;
	}

	void FindCards()
	{
		cardsTotalAmount = transform.childCount;
		cards = new Image[cardsTotalAmount];
		cards_ButtonComponents = new Button[cardsTotalAmount];

		for (int i = 0; i < cardsTotalAmount; i++)
		{
			int k = i;

			Transform child = transform.GetChild(i);
			Button b = child.GetComponent<Button>();

			cards[i] = child.GetComponent<Image>();
			cards_ButtonComponents[i] = b;

			b.onClick.AddListener(() => OnCardSelect(k));
		}
	}

	void AssignCardValues()
	{
		cardValues = new Dictionary<int, int>();

		int valuesCount = cards.Length / 2;
		int[] randomCardValues = GetRandomValues(valuesCount);

		List<int> cardIndexes = Enumerable.Range(0, cards.Length).ToList();

		for (int i = 0; i < valuesCount; i++)
			for (int j = 0; j < 2; j++)
				AssignCardValue(randomCardValues, cardIndexes, i);
	}

	void AssignCardValue(int[] randomCardValues, List<int> cardIndexes, int i)
	{
		int cardIndex = cardIndexes[Random.Range(0, cardIndexes.Count)];

		cardValues.Add(cardIndex, randomCardValues[i]);
		cardIndexes.Remove(cardIndex);
	}

	public void OnCardSelect(int index)
	{
		//If it's the same card selected
		if (index == firstSelectedCardIndex)
			return;

		//If first card not selected yet
		if (firstSelectedCardIndex == -1)
		{
			firstSelectedCardIndex = index;
			cards_ButtonComponents[index].enabled = false;
		}

		else
		{
			if (cardValues[index] == cardValues[firstSelectedCardIndex])
				StartCoroutine(RemoveBothCards(index));

			else
			{
				ToggleClick(block: true);
				StartCoroutine(FlipBackwardsBothCards(index));
			}
		}

		cards[index].sprite = cardSprites[cardValues[index]];
	}

	IEnumerator RemoveBothCards(int secondCardIndex)
	{
		yield return new WaitForSeconds(0.1f);
        
		cards_ButtonComponents[firstSelectedCardIndex].enabled = false;
		cards_ButtonComponents[secondCardIndex].enabled = false;
        //changed by Vlad
        cards[secondCardIndex].enabled = false;
        cards[firstSelectedCardIndex].enabled = false;
        //
        firstSelectedCardIndex = -1;

		cardsCollected += 2;
		if (cardsCollected == cardsTotalAmount)
			FindObjectOfType<EndGame>().Win();
	}

	void ToggleClick(bool block)
	{
		foreach (var b in cards_ButtonComponents)
			b.enabled = !block;
	}

	IEnumerator FlipBackwardsBothCards(int secondCardIndex)
	{
		yield return new WaitForSeconds(0.7f);

		cards[firstSelectedCardIndex].sprite = cardBack;
		cards[secondCardIndex].sprite = cardBack;

		firstSelectedCardIndex = -1;

		ToggleClick(block: false);
	}
}
