using UnityEngine;

[System.Serializable]
public class CalculateRandomPosition
{
	[SerializeField] Vector2 minPosition;
	[SerializeField] Vector2 maxPosition;
	
	internal Vector2 Calculate()
	{
		float positionX = Random.Range(minPosition.x, maxPosition.x);
		float positionY = Random.Range(minPosition.y, maxPosition.y);
		return new Vector2(positionX, positionY);
	}
	
}
