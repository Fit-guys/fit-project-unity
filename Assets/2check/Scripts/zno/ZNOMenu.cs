using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

//TODO: Rules, Results, Registration, Documents
//TODO: Select between english and physics
//TODO: Get CurLevelId, SubjectsCompleteStatus from database
public class ZNOMenu : MonoBehaviour
{
	[SerializeField] Image registrationBlock;
	[SerializeField] Button registrationButton;

	public static int CurLevelId { get; private set; }
	public static bool EnglishSelected { get; private set; }
	static bool[] SubjectsCompleteStatus = new bool[3];
    static bool znoChoosen = false;
    void Start()
	{
        if(!znoChoosen)
        {
            znoChoosen = true;
            UnityEngine.SceneManagement.SceneManager.LoadScene("choice_zno");
        }
           
        CheckRegistration();
        EnglishSelected = !ChooseSubject.physics;
        if (ChooseSubject.physics)
        {
            
            GameObject.Find("Third Subject").GetComponentInChildren<TextMeshProUGUI>().text = "Фізика";
            GameObject.Find("SubjectImagePhysic").GetComponent<Image>().enabled = true;
        }
        else
        {
            GameObject.Find("Third Subject").GetComponentInChildren<TextMeshProUGUI>().text = "Англійська мова";
            GameObject.Find("SubjectImageEnglish").GetComponent<Image>().enabled = true;
        }
	}

	void CheckRegistration()
	{
		if(SubjectsCompleteStatus.All(s => s))
		{
			registrationBlock.enabled = false;
			registrationButton.enabled = true;
		}
	}

	public static void OnSubjectCompleted()
	{
		SubjectsCompleteStatus[Mathf.Clamp(CurLevelId, 0, 2)] = true;
	}

	public void OnWheelButtonClick(int buttonID)
	{
		if (buttonID == 3)
			buttonID = 4;

		else if (buttonID == 2 && !EnglishSelected)
			buttonID = 3;

		CurLevelId = buttonID;

        if (buttonID <= 3)
            SceneManager.LoadScene("tests_zno");

        else
            SceneManager.LoadScene("Registration");
	}
}
