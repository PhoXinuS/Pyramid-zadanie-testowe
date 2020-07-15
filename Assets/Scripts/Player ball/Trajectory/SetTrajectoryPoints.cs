using UnityEngine;

public class SetTrajectoryPoints : MonoBehaviour
{
    public Vector2SO velocity;
    
    [SerializeField] GameObject trajectoryPointGameObject;
    [SerializeField] Transform trajectoryPointsParent;
    [SerializeField] int numberOfTrajectoryPoints = 12;
    [SerializeField] float maxWorldXCoordinate;
    [SerializeField] float groundHeight;

    private Vector2 previousVelocity;
    private GameObject[] trajectoryPoints;
    private CalculateTrajectoryPoints calculateTrajectory;
    
    private void Start()
    {
        calculateTrajectory = new CalculateTrajectoryPoints(-Physics2D.gravity.y);
        InstantiateTrajectoryPoints();
    }
    private void InstantiateTrajectoryPoints()
    {
        trajectoryPoints = new GameObject[numberOfTrajectoryPoints];
        for (int i = 0; i < numberOfTrajectoryPoints; i++)
        {
            GameObject trajectoryPoint = Instantiate(trajectoryPointGameObject, trajectoryPointsParent);
            trajectoryPoints[i] = trajectoryPoint;
        }
    }
	
    private void Update()
    {
        if (previousVelocity != velocity.variable)
        {
            SetPoints();
            previousVelocity = velocity.variable;
        }
    }

    private void SetPoints()
    {
        float distanceToTheGround = transform.position.y - groundHeight;
        float totalFlightTime = calculateTrajectory.TimeToHitTheGround(distanceToTheGround, velocity.variable);
        float timeStep = totalFlightTime / (numberOfTrajectoryPoints - 1);
        float time = 0f;
        foreach (var trajectoryPoint in trajectoryPoints)
        {
            Vector2 offset = transform.position - (Vector3.up * distanceToTheGround);
            Vector2 position = calculateTrajectory.CalculatePosition(time, distanceToTheGround, velocity.variable) + offset;
            trajectoryPoint.transform.position = position;
            if (PositionIsOverMaxXCoordinate(position))
            {
                if (PlayerEvents.LaunchBall != null) PlayerEvents.LaunchBall();
            }
            
            time += timeStep;
        }
    }

    private bool PositionIsOverMaxXCoordinate(Vector2 position)
    {
        return position.x > maxWorldXCoordinate;
    }
}