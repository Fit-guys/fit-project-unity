using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Pick
{
	public class MainManager : Singleton<MainManager>
	{
		public int winsToComplete = 5;

		[SerializeField] Button[] partPrefabs;
		GameObject[] gameParts;
		GameObject[] selectableParts;

		[SerializeField] RectTransform topPositions;
		[SerializeField] RectTransform bottomPositions;

		GameObject[] topParts;

		List<int> indexesLeft;
		Dictionary<int, int> topIndexes;

		//Set to -1 so it's 0 on first game load
		int winsCount = -1;

		public event Action OnWin = delegate { };
        public event Action OnLose = delegate { };
        Slider slider;
        float loseTime = 2;
        float curTime;
        bool decreaseTime = false;

        void Start()
        {
            OnLose = () => { Debug.Log("Loose"); UIPanelsManager.Instance.ShowLosePanel("pick_game"); };
            OnWin = () => { Debug.Log("Loose"); UIPanelsManager.Instance.ShowWinPanel("pick_game"); };
            SetParts();
            slider = GameObject.Find("Time Slider").GetComponent<Slider>();
            Load(true);
            //TODO: Change this
            ResetAndStartTimer(30);
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
		void SetParts()
		{
			int l = partPrefabs.Length;
			selectableParts = new GameObject[l];
			gameParts = new GameObject[l];
		}

		void SetValuesToDefault()
		{
			indexesLeft = Enumerable.Range(0, selectableParts.Length).ToList();
			topIndexes = new Dictionary<int, int>();
			topParts = new GameObject[topPositions.childCount];
		}

		private void ConfigureParts()
		{
			for (int i = 0; i < partPrefabs.Length; i++)
			{
				gameParts[i].GetComponent<Image>().color = new Color(1, 1, 1, 0.25f);
				gameParts[i].GetComponent<Button>().enabled = false;
				selectableParts[i].GetComponent<Image>().color = new Color(1, 1, 1, 1);


				selectableParts[i].SetActive(false);
				gameParts[i].SetActive(false);
			}
		}

		void Load(bool init)
		{
			if (++winsCount == winsToComplete)
				OnWin();
			if (init)
			{
				Transform sel = GameObject.Find("Selectable Parts").transform;
				Transform game = GameObject.Find("Game Parts").transform;

				for (int i = 0; i < partPrefabs.Length; i++)
				{
					selectableParts[i] = Instantiate(partPrefabs[i].gameObject, sel);
					gameParts[i] = Instantiate(partPrefabs[i].gameObject, game);
				}
			}

			ConfigureParts();
			SetValuesToDefault();
            Scrumble();
            //TODO: Change Time
            //TimeManager.Instance.ResetAndStartTimer(8);
        }

		void Scrumble()
		{
			int topCount = topPositions.childCount;
			int bottomCount = bottomPositions.childCount;

			GameObject[] bottomParts = new GameObject[bottomCount];

			for (int i = 0; i < topCount; i++)
			{
				var topPart = GetRandomPart(true);
				topParts[i] = topPart;

				topParts[i].transform.position = topPositions.GetChild(i).position;
				topParts[i].SetActive(true);
			}

			GetSameFromTop(bottomParts);

			for (int i = topCount; i < bottomCount; i++)
				bottomParts[i] = GetRandomPart(false);

			ShuffleBottomGameObjects(bottomParts);

			for (int i = 0; i < bottomParts.Length; i++)
			{
				bottomParts[i].transform.position = bottomPositions.GetChild(i).position;
				bottomParts[i].SetActive(true);
			}
		}

		void GetSameFromTop(GameObject[] bottomParts)
		{
			for (int i = 0; i < topIndexes.Count; i++)
				bottomParts[i] = selectableParts[topIndexes.FirstOrDefault(x => x.Value == i).Key];
		}

		GameObject GetRandomPart(bool top)
		{
			var num = indexesLeft[UnityEngine.Random.Range(0, indexesLeft.Count)];
			indexesLeft.Remove(num);

			if (top)
			{
				topIndexes.Add(num, topIndexes.Count);
				return gameParts[num];
			}

			return selectableParts[num];
		}

		void ShuffleBottomGameObjects(GameObject[] bot)
		{
			int l = bot.Length;
			for (int i = l; i > 1; i--)
			{
				int j = UnityEngine.Random.Range(0, l);

				GameObject tmp = bot[j];
				bot[j] = bot[i - 1];
				bot[i - 1] = tmp;
			}
		}

		public void OnPartClicked(GameObject part)
		{
			int indexOfPart = Array.IndexOf(selectableParts, part);

			part.GetComponent<Image>().color = new Color(0, 0, 0, 0);

			if (!topIndexes.ContainsKey(indexOfPart))
				OnWrongAnswer();

			else
			{
				int topButtonId = topIndexes[indexOfPart];

				topParts[topButtonId].GetComponent<Image>().color = new Color(1, 1, 1, 1);

				topIndexes.Remove(indexOfPart);

				if (topIndexes.Count == 0)
					Load(init: false);
            }
		}

		void OnWrongAnswer()
		{
			print("PartManager -- OnWrongAnswer");
		}
        public void ResetAndStartTimer(int loseTime)
        {
            slider.value = 1;
            curTime = 0;
            this.loseTime = loseTime;

            decreaseTime = true;
        }
    }
}
//Slider slider;
//float loseTime = 2;
//float curTime;
//bool decreaseTime = false;

//public event System.Action OnLose = delegate { };

//public void ResetAndStartTimer(int loseTime)
//{
//    slider.value = 1;
//    curTime = 0;
//    this.loseTime = loseTime;

//    decreaseTime = true;
//}

//void Start()
//{
//    Debug.Log("timeManager");
//    slider = GetComponent<Slider>();

//    //TODO: Change this
//    ResetAndStartTimer(4);
//}

//void Update()
//{
    //if (decreaseTime)
    //{
    //    curTime += Time.deltaTime;

    //    if (curTime >= loseTime)
    //    {
    //        decreaseTime = false;
    //        OnLose();
    //    }

    //    slider.value = 1 - curTime / loseTime;
    //}
//}