using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ZNOTestsAppearance))]
public class ZNOTests : MonoBehaviour
{
	#region Fields
	[SerializeField] Questions ukrainian;
	[SerializeField] Questions maths;
	[SerializeField] Questions english;
	[SerializeField] Questions physics;
	[Space]
	[SerializeField] TextMeshProUGUI questionTitle;
	[SerializeField] TextMeshProUGUI[] options;
	[Space]
	[SerializeField] Button prevButton;
	[SerializeField] Button nextButton;
	[SerializeField] TextMeshProUGUI rightButtonText;
	[Space]
	[SerializeField] Button[] options_Buttons;

	ZNOTestsAppearance appearance;

	Questions GetQuestions()
	{
		switch (ZNOMenu.CurLevelId)
		{
			case 0: return ukrainian;
			case 1: return maths;
			case 2: return english;
			case 3: return physics;
			default:
				throw new UnityException("GetQuestionAt -- Wrong ZnoManagerLevelId");
		}
	}

	int[] _answers { get; set; }
	int currentQuestionIndex = 0;
	#endregion

	public ZNOTests()
	{
		_answers = new int[10] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
	}

	void Start()
	{
		appearance = GetComponent<ZNOTestsAppearance>();

		SetUpQuestion();
	}

	void SetUpQuestion()
	{
		Question q = GetQuestions()[currentQuestionIndex];

		questionTitle.text = q.Title;

		for (int i = 0; i < 4; i++)
		{
			TextMeshProUGUI option = options[i];

			if (i == 0) option.text = q.OptionA;
			else if (i == 1) option.text = q.OptionB;
			else if (i == 2) option.text = q.OptionC;
			else option.text = q.OptionD;
		}

		prevButton.interactable = currentQuestionIndex != 0;
		rightButtonText.text = currentQuestionIndex == 9 ? "ЗАВЕРШИТИ!" : "ДАЛІ";

		ConfigureOptions(_answers[currentQuestionIndex]);
		appearance.SetSelectedOption(_answers[currentQuestionIndex]);
	}

	#region OnClicks
	public void OnOptionClick(int index)
	{
		if (_answers[currentQuestionIndex] == index)
			return;

		_answers[currentQuestionIndex] = index;

		ConfigureOptions(index);
		appearance.SetSelectedOption(index);
	}

	void ConfigureOptions(int indexOfSelected)
	{
		for (int i = 0; i < 4; i++)
			options_Buttons[i].interactable = !(i == indexOfSelected);
	}

	public void TransitionTo(bool next)
	{
		currentQuestionIndex += next ? 1 : -1;

		if(currentQuestionIndex == 10)
		{
			EndTest();
			return;
		}

		SetUpQuestion();
	}
	#endregion

	void EndTest()
	{
		//Consider making event
		ZNOResults.CalculateScore(_answers, GetQuestions());
		ZNOMenu.OnSubjectCompleted();

		SceneManager.LoadScene("menu_zno");
	}
}