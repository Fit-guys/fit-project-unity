using UnityEngine;

namespace Doodle
{
	public class CloudManager : MonoBehaviour
	{
		[SerializeField] GameObject[] cloudPrefabs;
		[SerializeField] int cloudsAmount;

		void Start()
		{
			Transform cloudHolder = new GameObject("Cloud Holder").transform;
			cloudHolder.SetParent(Camera.main.transform);

			for (int i = 0; i < cloudsAmount; i++)
				Instantiate(cloudPrefabs[Random.Range(0, cloudPrefabs.Length)], cloudHolder);
		}
	}

}