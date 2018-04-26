using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
	[SerializeField] int platformsAmount = 50;
	[Space]
	[SerializeField] GameObject platformPrefab;
	GameObject initialPlatforms;

	const float HALF_PLATFORM_WIDTH = 0.5f;
	const float OFFSET = 0.02f;
	float halfScreenHeight;

	float curY = -1;
	bool initialPlatformsRemoved = false;

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
		halfScreenHeight = -c.y;

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
		if(platforms.Peek().transform.position.y < mainCamTransform.position.y - halfScreenHeight)
		{
			GameObject d = platforms.Dequeue();
			Destroy(d);

			return true;
		}
		return false;
	}
}
