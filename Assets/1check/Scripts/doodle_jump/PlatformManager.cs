using System.Collections.Generic;
using UnityEngine;

namespace Doodle
{
	public class PlatformManager : Singleton<PlatformManager>
	{
		public float HalfScreenHeight;
		[SerializeField] int platformsAmount = 50;
		[Space]
		[SerializeField] GameObject platformPrefab;
		GameObject initialPlatforms;

		const float HALF_PLATFORM_WIDTH = 0.5f;
		const float OFFSET = 0.02f;

		float curY = -1;

		float initialDistanceBetweenPlatformsY = 0.5f;
		const float distanceYIncreaser = 0.03f;

		Queue<GameObject> platforms = new Queue<GameObject>();

		Transform mainCamTransform;

		void Start()
		{
			mainCamTransform = Camera.main.transform;

			initialPlatforms = GameObject.Find("Initial Platforms");
			platforms.Enqueue(initialPlatforms);

			Transform platformsHolder = new GameObject("Platforms Holder").transform;

			Vector3 c = Camera.main.ScreenToWorldPoint(Vector2.zero);

			float minX = c.x + HALF_PLATFORM_WIDTH + OFFSET;
			float maxX = minX * -1;
			HalfScreenHeight = -c.y;

			for (int i = 0; i < platformsAmount; i++)
			{
				GameObject platform = Instantiate(platformPrefab, new Vector2(Random.Range(minX, maxX), curY), Quaternion.identity, platformsHolder);
				platforms.Enqueue(platform);

				curY += initialDistanceBetweenPlatformsY + distanceYIncreaser * i;
			}
		}

		void Update()
		{
			RemoveLowestPlatform();
		}

		bool RemoveLowestPlatform()
		{
			if (platforms.Peek().transform.position.y - 0.1f < mainCamTransform.position.y - HalfScreenHeight)
			{
                Player.score++;
				GameObject d = platforms.Dequeue();
				Destroy(d);

				return true;
			}
			return false;
		}
	} 
}
