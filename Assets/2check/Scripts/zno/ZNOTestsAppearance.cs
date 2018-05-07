using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ZNOTests))]
public class ZNOTestsAppearance : MonoBehaviour
{
	#region Fields
	[SerializeField] TextMeshProUGUI header;
	[Space]
	[SerializeField] Color[] titleColors;
	[Space]
	[SerializeField] TextMeshProUGUI questionTitle;
	[SerializeField] Image[] options;
	[Space]
	[SerializeField] Image prev;
	[SerializeField] Image next;
	[Space]
	[SerializeField] Sprite pressedButton;
	[Space]
	[Header("Images")]
	[SerializeField] ZnoButtonImages[] znoButtonImages;

	const string HEADER_BEGINNING = "<#00CAFFFF>ЗОВНІШНЄ НЕЗАЛЕЖНЕ ОЦІНЮВАННЯ</color><color=yellow>";

	readonly string[] headerEnding = new string[4]
	{
		"\nЗ УКРАЇНСЬКОЇ МОВИ",
		"\nЗ МАТЕМАТИКИ",
		"\nЗ АНГЛІЙСЬКОЇ МОВИ",
		"\nЗ ФІЗИКИ"
	}; 
	#endregion

	void Awake()
	{
		SetHeader();
		SetAppearance(Mathf.Clamp(ZNOMenu.CurLevelId, 0, 2));
	}

	void SetHeader()
	{
		header.text = HEADER_BEGINNING + headerEnding[ZNOMenu.CurLevelId];
	}

	void SetAppearance(int index)
	{
		questionTitle.color = titleColors[index];

		ZnoButtonImages z = znoButtonImages[index];

		SpriteState ss = new SpriteState
		{
			highlightedSprite = z.wideHighlighted
		};

		for (int i = 0; i < options.Length; i++)
		{
			options[i].sprite = z.wide;
			options[i].GetComponent<Button>().spriteState = ss;
		}

		next.sprite = z.narrow;
		prev.sprite = z.narrow;
	}

	public void SetSelectedOption(int index)
	{
		for (int i = 0; i < 4; i++)
			options[i].sprite = i == index ? pressedButton : znoButtonImages[Mathf.Clamp(ZNOMenu.CurLevelId, 0, 2)].wide;
	}
}
