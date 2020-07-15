using UnityEngine;

public class LaunchBall : MonoBehaviour
{
     [SerializeField] string launchBall = "space";
     
     private void Update()
     {
          if (Input.GetKeyUp(launchBall))
          {
               if (PlayerEvents.LaunchBall != null) PlayerEvents.LaunchBall();
          }
     }
}