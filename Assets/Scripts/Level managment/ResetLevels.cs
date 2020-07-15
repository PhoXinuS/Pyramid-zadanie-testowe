using UnityEngine;

public class ResetLevels : MonoBehaviour
{
    public void Reset()
    {
        if (Events.ResetLevels != null) Events.ResetLevels();
    }
}