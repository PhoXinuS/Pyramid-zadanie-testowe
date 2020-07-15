using UnityEngine;

public class ResetIntSO : MonoBehaviour
{
    public IntSO intToReset;
    [SerializeField] int resetValue;

    private void Start()
    {
        Events.ResetLevels += Reset;
        Reset();
    }

    private void Reset()
    {
        intToReset.variable = resetValue;
    }

    private void OnDestroy()
    {
        Events.ResetLevels -= Reset;
    }
} 
