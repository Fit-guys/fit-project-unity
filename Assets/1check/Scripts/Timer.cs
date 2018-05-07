using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	[SerializeField] float maxTimeLeft;

	Image loadingBar;

	float timeLeft;

	bool decreaseTime = false;

	public void AddTime(float toAdd)
	{
		timeLeft = Mathf.Clamp(timeLeft + toAdd, 0, maxTimeLeft);
	}

	public void ResetAndStartTimer()
	{
		loadingBar.fillAmount = 1;
		timeLeft = maxTimeLeft;

		decreaseTime = true;
	}

	public void StopTimer()
	{
		decreaseTime = false;
	}

	void Start()
	{
		loadingBar = transform.GetChild(0).GetComponent<Image>();

		ResetAndStartTimer();
	}

	void Update()
	{
		if (decreaseTime)
		{
			timeLeft -= Time.deltaTime;

			if (timeLeft < 0)
			{
				StopTimer();

				FindObjectOfType<EndGame>().Lose();
			}

			loadingBar.fillAmount =	 timeLeft / maxTimeLeft;
		}
	}
}