using System;
using System.Collections;
using UnityEngine;

public class DelayedTargetDetection : MonoBehaviour
{
    public FloatSO timeLeftToDetect;

    [SerializeField] LayerMask whatIsGround;
    [SerializeField] float delayTime;

    private ITarget[] targets;
    private bool timerIsCounting = false;
    private bool canCount;
    private int collisionCount = 0;

    private void Start()
    {
        PlayerEvents.BallLaunched += EnableCounter;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        targets = other.gameObject.GetComponents<ITarget>();
        if (targets.Length != 0)
        {
            collisionCount++;
        }
    }
 
    private void OnTriggerExit2D(Collider2D other)
    {
        targets = other.gameObject.GetComponents<ITarget>();
        if (targets.Length != 0)
        {
            collisionCount--;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (whatIsGround.Contains(other.gameObject.layer))
        {
            StartTimer();
        }
    }
    
    private void EnableCounter()
    {
        canCount = true;
    }
    
    private void StartTimer()
    {
        if (!timerIsCounting && canCount)
        {
            canCount = false;
            StartCoroutine(DelayTimer());
        }
    }

    private IEnumerator DelayTimer()
    {
        timerIsCounting = true;
        timeLeftToDetect.variable = delayTime;

        while (timeLeftToDetect.variable > 0f)
        {
            yield return null;
            timeLeftToDetect.variable -= Time.deltaTime;
        }
        timerIsCounting = false;

        if (IsColliding())
        {
            DetectedTarget();
        }
        else
        {
            TargetNotDetected();
        }
    }

    private bool IsColliding()
    {
        return collisionCount > 0;
    }
    
    private void DetectedTarget()
    {
        foreach (var target in targets)
        {
            target.OnTargetDetected();
        }
        if (PlayerEvents.OnTargetDetected != null) PlayerEvents.OnTargetDetected();
    }
    private static void TargetNotDetected()
    {
        if (Events.GameOver != null) Events.GameOver();
    }

    private void OnDestroy()
    {
        PlayerEvents.BallLaunched -= EnableCounter;
    }
}
    
