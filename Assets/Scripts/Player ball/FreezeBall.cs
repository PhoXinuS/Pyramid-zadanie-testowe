using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FreezeBall : MonoBehaviour
{
	private Rigidbody2D rb2D;
	
	private void Start()
	{
		rb2D = gameObject.GetComponent<Rigidbody2D>();
		
		Events.LoadNextLevel += Freeze;
		Events.ResetLevels += Freeze;
		PlayerEvents.BallLaunched += UnFreeze;
		
		Freeze();
	}

	private void Freeze()
	{
		rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
	}

	private void UnFreeze()
	{	
		rb2D.constraints = RigidbodyConstraints2D.None;
	}

	private void OnDestroy()
	{
		Events.LoadNextLevel -= Freeze;
		Events.ResetLevels -= Freeze;
		PlayerEvents.BallLaunched -= UnFreeze;
	}
}
