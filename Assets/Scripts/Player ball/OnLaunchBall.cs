using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class OnLaunchBall : MonoBehaviour
{
    public Vector2SO launchVelocity;

    private Rigidbody2D rb2D;
    private bool canLaunch = true;
    
    private void Start()
    {
        Events.LoadNextLevel += EnableLaunchOnLevelLoad;
        Events.ResetLevels += EnableLaunchOnLevelLoad;
        PlayerEvents.LaunchBall += Launch;
        
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }
    
    private void EnableLaunchOnLevelLoad()
    {
        canLaunch = true;
    }
    
    private void Launch()
    {
        if (canLaunch)
        {
            canLaunch = false;
            AddVelocity();
            if (PlayerEvents.BallLaunched != null) PlayerEvents.BallLaunched();
        }
    }
    private void AddVelocity()
    {
        rb2D.velocity = launchVelocity.variable;
    }

    private void OnDestroy()
    {
        Events.LoadNextLevel -= EnableLaunchOnLevelLoad;
        Events.ResetLevels -= EnableLaunchOnLevelLoad;    
        PlayerEvents.LaunchBall -= Launch;

    }
}