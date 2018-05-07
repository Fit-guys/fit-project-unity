using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ZNOResults : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI ukrainianScoreText;
	[SerializeField] TextMeshProUGUI mathsScoreText;
	[SerializeField] TextMeshProUGUI thirdScoreText;
	[Space]
	[SerializeField] Image thirdImage;
	[Space]
	[SerializeField] Sprite englishSprite;
	[SerializeField] Sprite physicsSprite;

	public static int _UkrainianScore = -1;
	public static int _MathsScore = -1;
	public static int _ThirdScore = -1;

	void Start()
	{
		SetScoreTexts();

		SetThirdImage();
	}

	void SetScoreTexts()
	{
		ukrainianScoreText.text = _UkrainianScore == -1 ? "---" : _UkrainianScore.ToString();
		mathsScoreText.text = _MathsScore == -1 ? "---" : _MathsScore.ToString();
		thirdScoreText.text = _ThirdScore == -1 ? "---" : _ThirdScore.ToString();
	}

	void SetThirdImage()
	{
		thirdImage.sprite = ZNOMenu.EnglishSelected ? englishSprite : physicsSprite;
	}

	public static void CalculateScore(int[] answers, Questions q)
	{
		int score = 100;

		for (int i = 0; i < 10; i++)
		{
			if (answers[i] == q[i].answerId)
				score += 10;
		}

		switch (ZNOMenu.CurLevelId)
		{
			case 0:
				_UkrainianScore = score;
				break;
			case 1:
				_MathsScore = score;
				break;
			case 2:
			case 3:
				_ThirdScore = score;
				break;
		}
	}
}
