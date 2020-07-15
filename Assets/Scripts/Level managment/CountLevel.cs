using UnityEngine;

public class CountLevel : MonoBehaviour 
{
	public IntSO currentActiveLevel;

	private void Awake()
	{
		Events.ResetLevels += LevelReset;
		Events.LoadNextLevel += LevelIncreased;
		
		LevelReset();
	}

	private void LevelReset()
	{
		currentActiveLevel.variable = 0;
	}
	
	private void LevelIncreased()
	{
		currentActiveLevel.variable += 1;
	}
	
	
	private void OnDestroy()
	{
		Events.ResetLevels -= LevelReset;
		Events.LoadNextLevel -= LevelIncreased;
	}
	
}
