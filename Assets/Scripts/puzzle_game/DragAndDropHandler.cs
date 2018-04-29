using UnityEngine;

public class DragAndDropHandler : MonoBehaviour
{
	Vector2 clickOffset;
	RectTransform selectedPuzzle;

	public void OnBeginDrag(RectTransform puzzle)
	{
		selectedPuzzle = puzzle;
		clickOffset = Input.mousePosition - transform.position;

		print(clickOffset);
	}

	public void OnDrag()
	{
		selectedPuzzle.position = (Vector2)Input.mousePosition - clickOffset;

		print(clickOffset);
	}

	public void OnEndDrag()
	{
		
	}
}
