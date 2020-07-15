using UnityEngine;

public class SpaceInput : MonoBehaviour, IInput
{
	public bool inputIsActive { get; private set; }

	private void Update()
	{
		inputIsActive = Input.GetKey(KeyCode.Space);
	}
}
