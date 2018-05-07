using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Window : MonoBehaviour
{
	[SerializeField] int numberOfArrows = 100;
	[Space]
	[SerializeField] TextMeshProUGUI arrowsLeftText;
	[Header("Arrow Sprites")]
	[SerializeField] Sprite upArrowSprite;
	[SerializeField] Sprite rightArrowSprite;
	[SerializeField] Sprite downArrowSprite;
	[SerializeField] Sprite leftArrowSprite;

	Transform arrowHolder;

	readonly KeyCode[] arrows = new KeyCode[4]
	{
			KeyCode.UpArrow,
			KeyCode.RightArrow,
			KeyCode.DownArrow,
			KeyCode.LeftArrow
	};

	KeyCode[] arrowSequence;

	int _curArrowToPress;

	int CurArrowToPress
	{
		get { return _curArrowToPress; }
		set
		{
			_curArrowToPress = value;

			arrowsLeftText.text = (numberOfArrows - _curArrowToPress).ToString();
		}
	}

	const int NUMBER_OF_ARROWS_IN_SCENE = 10; // changed

	void Start()
	{
		arrowHolder = GameObject.Find("Arrow Holder").transform;

		CurArrowToPress = 0;

		SetArrowSequence();

		for (int i = 0; i < NUMBER_OF_ARROWS_IN_SCENE; i++)
            if(arrowHolder.childCount > 0)
			    SetSprite(arrowHolder.GetChild(i), arrowSequence[i]);
	}

	void SetArrowSequence()
	{
		arrowSequence = new KeyCode[numberOfArrows];

		for (int i = 0; i < numberOfArrows; i++)
			arrowSequence[i] = arrows[Random.Range(0, 4)];
	}

	void SetSprite(Transform arrow, KeyCode key)
	{
		Image kidImg = arrow.GetComponent<Image>();

		if (key == KeyCode.UpArrow)
			kidImg.sprite = upArrowSprite;

		else if (key == KeyCode.RightArrow)
			kidImg.sprite = rightArrowSprite;

		else if (key == KeyCode.DownArrow)
			kidImg.sprite = downArrowSprite;

		else if (key == KeyCode.LeftArrow)
			kidImg.sprite = leftArrowSprite;

		else
		{
			Debug.LogError("SetSprite() -- Wrong key");
			return;
		}
	}

	void Update()
	{
		if (CurArrowToPress < numberOfArrows && Input.GetKeyDown(arrowSequence[CurArrowToPress]))
			KillArrow();
	}

	void KillArrow()
	{
		int index = CurArrowToPress++ + NUMBER_OF_ARROWS_IN_SCENE;

		Transform killed = arrowHolder.GetChild(0);
		killed.SetAsLastSibling();

		if (index < numberOfArrows)
			SetSprite(killed, arrowSequence[index]);

		else
			killed.GetComponent<Image>().color = new Color(1, 1, 1, 0);

		if (CurArrowToPress == numberOfArrows)
		{
			FindObjectOfType<EndGame>().Win();
		}
	}
}
