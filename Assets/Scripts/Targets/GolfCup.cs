using UnityEngine;

public class GolfCup : MonoBehaviour, ITarget
{
    [SerializeField] int scoreToAdd = 1;

    public void OnTargetDetected()
    {
        if (Events.AddScore != null) Events.AddScore(scoreToAdd);
    }
}