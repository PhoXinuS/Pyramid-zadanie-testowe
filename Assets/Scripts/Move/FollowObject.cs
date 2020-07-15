using UnityEngine;

public class FollowObject : MonoBehaviour
{
	public Transform objectToFollow;
	[SerializeField] Vector3 offset;
	
	private void LateUpdate()
	{
		transform.position = objectToFollow.position + offset;
	}
}
