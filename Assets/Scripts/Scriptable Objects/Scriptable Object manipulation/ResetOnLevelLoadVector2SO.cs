using UnityEngine;

public class ResetOnLevelLoadVector2SO : MonoBehaviour
{
    public Vector2SO vectorToReset;
    
    [SerializeField] Vector2 resetValue;

    private void Start()
    {
        Events.ResetLevels += Reset;
        Events.LoadNextLevel += Reset;
        
        Reset();
    }

    private void Reset()
    {
        vectorToReset.variable = resetValue;
    }

    private void OnDestroy()
    {
        Events.ResetLevels -= Reset;
        Events.LoadNextLevel -= Reset;
    }
}