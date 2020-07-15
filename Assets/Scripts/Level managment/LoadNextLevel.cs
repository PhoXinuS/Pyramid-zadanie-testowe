using UnityEngine;

public class LoadNextLevel : MonoBehaviour
{
    private void Start()
    {
        PlayerEvents.OnTargetDetected += Load;
    }

    private void Load()
    {
        if (Events.LoadNextLevel != null) Events.LoadNextLevel();
    }

    private void OnDestroy()
    {
        PlayerEvents.OnTargetDetected -= Load;
    }
}