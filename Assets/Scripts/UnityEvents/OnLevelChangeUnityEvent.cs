using UnityEngine;
using UnityEngine.Events;

public class OnLevelChangeUnityEvent : MonoBehaviour
{
	public UnityEvent OnChange;

	private void Start()
	{
		Events.LoadNextLevel += Activate;
		Events.ResetLevels += Activate;
	}

	private void Activate()
	{
		OnChange.Invoke();
	}
	
	private void OnDisable()
	{
		Events.LoadNextLevel -= Activate;
		Events.ResetLevels -= Activate;
	}
}
