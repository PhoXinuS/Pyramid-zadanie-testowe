using UnityEngine;

public class ChangePositionOnLevelLoad : MonoBehaviour
{
    [SerializeField] Vector2 startingPosition;
    [SerializeField] CalculateRandomPosition randomPosition = new CalculateRandomPosition();

    private void Start()
    {
        SetStartingPosition();
        
        Events.ResetLevels += SetStartingPosition;
        Events.LoadNextLevel += SetRandomPosition;
    }

    private void SetStartingPosition()
    {
        transform.position = startingPosition;
    }

    private void SetRandomPosition()
    {
        transform.position = randomPosition.Calculate();
    }
    
    private void OnDestroy()
    {
        Events.ResetLevels -= SetStartingPosition;
        Events.LoadNextLevel -= SetRandomPosition;
    }
}
