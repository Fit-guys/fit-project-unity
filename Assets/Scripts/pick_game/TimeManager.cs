using UnityEngine;
using UnityEngine.UI;

public class TimeManager : Singleton<TimeManager>
{
	Slider slider;
	float loseTime = 2;
	float curTime;
	bool decreaseTime = false;

	public event System.Action OnLose = delegate { };

	public void ResetAndStartTimer(int loseTime)
	{
		slider.value = 1;
		curTime = 0;
		this.loseTime = loseTime;

		decreaseTime = true;
	}

	void Start()
	{
		slider = GetComponent<Slider>();

		//TODO: Change this
		ResetAndStartTimer(4);
	}

	void Update()
	{
		if (decreaseTime)
		{
			curTime += Time.deltaTime;

			if (curTime >= loseTime)
			{
				decreaseTime = false;
				OnLose();
			}

			slider.value = 1 - curTime / loseTime;
		}
	}
}