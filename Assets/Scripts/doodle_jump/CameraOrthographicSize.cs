using UnityEngine;

public class CameraOrthographicSize : MonoBehaviour
{
	const float TARGET_ASPECT = 16f / 9f;
	const float START_ORTHO = 5;
	Camera cam;

	void Start()
	{
		cam = GetComponent<Camera>();
	}

	void Update()
	{
		float curAspect = (float)Screen.width / (float)Screen.height; ;
		
		if(curAspect != TARGET_ASPECT)
			cam.orthographicSize = TARGET_ASPECT / curAspect * START_ORTHO;
	}
}
