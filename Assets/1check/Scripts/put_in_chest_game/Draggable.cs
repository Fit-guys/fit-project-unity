using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
	Vector2 clickOffset;
	Vector3 initialPos;

	void Awake()
	{
		initialPos = transform.localPosition;
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		clickOffset = eventData.position - (Vector2)transform.position;

		GetComponent<CanvasGroup>().blocksRaycasts = false;
		Chest.FruitIsBeingHeld = true;

		transform.parent.SetAsLastSibling();
	}

	public void OnDrag(PointerEventData eventData)
	{
		transform.position = eventData.position - clickOffset;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		transform.localPosition = initialPos;

		GetComponent<CanvasGroup>().blocksRaycasts = true;
		Chest.FruitIsBeingHeld = false;
	}

	void OnEnable()
	{
		GetComponent<CanvasGroup>().blocksRaycasts = true;
		transform.localPosition = initialPos;
	}

}
