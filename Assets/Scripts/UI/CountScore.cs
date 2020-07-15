using UnityEngine;

public class CountScore : MonoBehaviour
{
	public IntSO score;
	[SerializeField] bool count = true;

	private void Start()
	{
		Events.AddScore += AddScore;
	}

	private void AddScore(int scoreToAdd)
	{
		if (count)
		{
			score.variable += scoreToAdd;
		}
	}

	private void OnDestroy()
	{
		Events.AddScore -= AddScore;
	}
}
