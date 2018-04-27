using UnityEngine;
using UnityEngine.UI;

namespace Pick
{
	public class TimeManager : Singleton<TimeManager>
	{
		[SerializeField] Slider slider;
		float loseTime = 2;
		float curTime;
		bool decreaseTime = false;

		public event System.Action OnLose;

		public void ResetAndStartTimer(int loseTime)
		{
			slider.value = 1;
			curTime = 0;
			this.loseTime = loseTime;

			decreaseTime = true;
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
}