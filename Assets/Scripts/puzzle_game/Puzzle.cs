using UnityEngine;
using UnityEngine.EventSystems;

namespace PuzzleGame
{
	public class Puzzle : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
	{
		[SerializeField] int id;
		Vector2 clickOffset;

		public void OnBeginDrag(PointerEventData eventData)
		{
			clickOffset = eventData.position - (Vector2)transform.position;
		}

		public void OnDrag(PointerEventData eventData)
		{
			transform.position = eventData.position - clickOffset;
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			Transform puzzleHolder = MainManager.Instance.puzzleHolders[id];

			Debug.Log(puzzleHolder.position);

			float d = Vector2.Distance(puzzleHolder.position, this.transform.position);

			print(d);

			if (d < 150)
			{
				transform.SetParent(puzzleHolder);
				transform.localPosition = Vector2.zero;
				this.enabled = false;

				//Temp shitty code
				MainManager.PlacedPuzzleCount++;
			}

			else
			{
				GetComponent<RectTransform>().localPosition = Vector2.zero;
			}
		}
	}
}
