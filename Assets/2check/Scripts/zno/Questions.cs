using UnityEngine;

[CreateAssetMenu(fileName = "New Questions", menuName = "Questions")]
public class Questions : ScriptableObject
{
	[SerializeField] Question[] questions;

	public Question this[int index]
	{
		get { return questions[index]; }
	}
}
