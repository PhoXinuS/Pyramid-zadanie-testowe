using UnityEngine;
using UnityEngine.Events;

public class OnBallShotUnityEvent : MonoBehaviour
{
    public UnityEvent OnShot;

    private void Start()
    {
        PlayerEvents.BallLaunched += Activate;
    }

    private void Activate()
    {
        OnShot.Invoke();
    }
	
    private void OnDisable()
    {
        PlayerEvents.BallLaunched -= Activate;
    }
}