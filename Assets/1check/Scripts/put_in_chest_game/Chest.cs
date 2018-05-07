using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Chest : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
	[SerializeField] int winsToComplete = 3;
	[SerializeField] float timeToAdd;
	[Space]
	[SerializeField] Sprite opened;

	public static bool FruitIsBeingHeld = false;

	Sprite closed;

	int droppedItemsCount;
	GameObject[] food;

	Image image;

	int curWinCount = 0;

	void Start()
	{
		image = GetComponent<Image>();
		closed = image.sprite;

		food = GameObject.FindGameObjectsWithTag("Food");
	}

	public void OnDrop(PointerEventData eventData)
	{
		eventData.pointerDrag.SetActive(false);
		FruitIsBeingHeld = false;

		droppedItemsCount++;
		if (droppedItemsCount == food.Length)
		{
			curWinCount++;
			if(curWinCount == winsToComplete)
			{
				FindObjectOfType<EndGame>().Win();
				return;
			}

			FindObjectOfType<Timer>().AddTime(timeToAdd);

			for (int i = 0; i < food.Length; i++)
				food[i].SetActive(true);

			droppedItemsCount = 0;
		}

		image.sprite = closed;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if(FruitIsBeingHeld)
			image.sprite = opened;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if(FruitIsBeingHeld)
			image.sprite = closed;
	}
}
