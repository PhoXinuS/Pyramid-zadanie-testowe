using UnityEngine;

public class FloatSODependentOnLevel : MonoBehaviour
{
	public FloatSO floatToIncrease;
	public IntSO currentActiveLevel;

	[SerializeField] float baseFloat = 0.2f;
	[SerializeField] float maxFloat = 3f;
	[SerializeField] float increasePerLevel = 0.1f;


	private void Start()
	{
		Events.ResetLevels += ResetFloatScriptableObject;
		Events.LoadNextLevel += SetFloatScriptableObject;

		ResetFloatScriptableObject();
	}

	private void ResetFloatScriptableObject()
	{
		floatToIncrease.variable = baseFloat;
	}
	
	private void SetFloatScriptableObject()
	{
		float value = baseFloat + increasePerLevel * currentActiveLevel.variable;
		if (value > maxFloat)
		{
			value = maxFloat;
		}
		floatToIncrease.variable = value;
	}
	
	private void OnDestroy()
	{
		Events.ResetLevels -= ResetFloatScriptableObject;
		Events.LoadNextLevel -= SetFloatScriptableObject;
	}
}
