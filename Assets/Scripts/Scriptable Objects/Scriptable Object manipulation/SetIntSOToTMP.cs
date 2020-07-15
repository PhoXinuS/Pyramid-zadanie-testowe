using System;
using TMPro;
using UnityEngine;

public class SetIntSOToTMP : MonoBehaviour
{
	public TMP_Text fieldToSet;
	public IntSO intScriptableObject;

	private int currentSetValue = 0;

	private void Start()
	{
		SetField(currentSetValue);
	}

	private void Update()
	{
		if (ValueChanged())
		{
			SetField(intScriptableObject.variable);
			currentSetValue = intScriptableObject.variable;
		}
	}

	private void SetField(int fieldValue)
	{
		string text = String.Format("{0:D5}", fieldValue);
		fieldToSet.text = text;
	}

	private bool ValueChanged()
	{
		return intScriptableObject.variable != currentSetValue;
	}
}
