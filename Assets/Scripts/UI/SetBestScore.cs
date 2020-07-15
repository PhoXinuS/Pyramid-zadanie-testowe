using UnityEngine;

public class SetBestScore : MonoBehaviour
{
	public IntSO score;
	public IntSO bestScore;
	
	private void Start()
	{
		Events.GameOver += SetBest;
	}

	private void SetBest()
	{
		if (score.variable > bestScore.variable)
		{
			bestScore.variable = score.variable;
		}
	}
	
	private void OnDestroy()
	{
		Events.GameOver -= SetBest;
	}
}
