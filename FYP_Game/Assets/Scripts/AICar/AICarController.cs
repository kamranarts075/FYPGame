using UnityEngine;

public class AICarController : MonoBehaviour
{
    [Header("Waypoints")]
    public Transform[] waypoints; // Waypoints for navigation
    public float speed = 10f; // Normal speed
    public float rotationSpeed = 5f; // Rotation speed
    public float waypointThreshold = 1f; // Distance to waypoint for switching

    [Header("Obstacle Detection")]
    public float rayLength = 5f; // Distance to check for obstacles
    public float stopDistance = 2f; // Minimum distance to stop
    public float slowDownSpeed = 3f; // Speed when avoiding obstacles
    public LayerMask obstacleLayer; // Layers considered as obstacles

    private int currentWaypointIndex = 0; // Track current waypoint

    void Update()
    {
        // Check for obstacles using raycasting
        bool obstacleDetected = DetectObstacle();

        // Adjust speed based on obstacle presence
        float currentSpeed = obstacleDetected ? slowDownSpeed : speed;

        // Move towards the current waypoint
        MoveTowardsWaypoint(currentSpeed);
    }

    void MoveTowardsWaypoint(float currentSpeed)
    {
        if (waypoints.Length == 0) return;

        // Get the current waypoint
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;

        // Move the car
        transform.position += direction * currentSpeed * Time.deltaTime;

        // Rotate towards the waypoint
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Check if the car has reached the waypoint
        float distanceToWaypoint = Vector3.Distance(transform.position, targetWaypoint.position);
        if (distanceToWaypoint < waypointThreshold)
        {
            // Move to the next waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    bool DetectObstacle()
    {
        // Cast a ray forward to detect obstacles
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength, obstacleLayer))
        {
            float distanceToObstacle = hit.distance;

            // Stop or slow down if obstacle is close
            if (distanceToObstacle < stopDistance)
            {
                Debug.Log("Obstacle too close, stopping!");
                return true;
            }

            Debug.Log("Obstacle detected, slowing down.");
            return true;
        }

        // No obstacle detected
        return false;
    }

    bool DetectSideObstacles()
    {
        Vector3 leftRay = transform.position - transform.right * 0.5f;
        Vector3 rightRay = transform.position + transform.right * 0.5f;

        RaycastHit hit;
        if (Physics.Raycast(leftRay, transform.forward, out hit, rayLength, obstacleLayer) ||
            Physics.Raycast(rightRay, transform.forward, out hit, rayLength, obstacleLayer))
        {
            Debug.Log("Side obstacle detected!");
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        // Visualize the raycast in the Scene view
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * rayLength);
    }
}
