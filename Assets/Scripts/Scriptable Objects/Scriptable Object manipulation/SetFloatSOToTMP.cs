using System;
using TMPro;
using UnityEngine;

public class SetFloatSOToTMP : MonoBehaviour
{
	public TMP_Text textToSet;
	public FloatSO floatScriptableObject;

	private float previousFloat;

	private void Start()
	{
		textToSet.text = " ";
	}
	
	private void Update()
	{
		if (FloatHasChangedWithTolerance())
		{
			previousFloat = floatScriptableObject.variable;
			if (floatScriptableObject.variable > 0f)
			{
				textToSet.text = floatScriptableObject.variable.ToString("F2");
			}
			else
			{
				textToSet.text = " ";
			}
		}
	}

	private bool FloatHasChangedWithTolerance()
	{
		return Math.Abs(previousFloat - floatScriptableObject.variable) > 0.01f;
	}
}
