using UnityEngine;
using UnityEngine.Audio;

public class EnemyAI : MonoBehaviour
{
    public float RotationAmplifier = 1f;
    private PatrolRoute patrolRoute;
    private int index = 0;
    private EnemyMovement enemyMovement;
    private EnemyShooting enemyShooting;
    private float waitTime = 0f;
    private bool changingDirection = false;
    public GameObject Target;
    void Start()
    {
        patrolRoute = GetComponentInChildren<PatrolRoute>();
        if(patrolRoute == null)
        {
            Debug.LogError("PatrolRoute component not found in children.");
            return;
        }
        enemyMovement = GetComponent<EnemyMovement>();
        enemyShooting = GetComponent<EnemyShooting>();
        Target = GameObject.Find("Player_Mesh");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyShooting.Chase)
        {
            enemyMovement.MoveForward();
        }
        if (enemyShooting.IsShooting)
        {
            
            changingDirection = true;
            return; // If the enemy is shooting, do not move
        }
        if (changingDirection)
        {
            HeadToWaypoint(); // Face the next waypoint
            return;
        }
        if (waitTime > 0f)
        {
            waitTime -= Time.deltaTime; // Decrease wait time
            if(waitTime <= 0f)
            {
                changingDirection = true;
            }
            return; // Skip movement logic while waiting
        }
        else
        {
            HeadToWaypoint();
            enemyMovement.MoveForward();
        }
    }
    private void HeadToWaypoint()
    {

        Transform waypoint = patrolRoute.GetWaypoint(index);
        Vector3 direction = (waypoint.position - transform.position);
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, angle, 0), Time.deltaTime * RotationAmplifier);
        if(Quaternion.Angle(transform.rotation, Quaternion.Euler(0, angle, 0)) < 1f)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, angle, 0); // Snap to the exact rotation when close enough
            changingDirection = false; // Stop changing direction when facing the waypoint
        }
    }

    private void handleWaypointCHange()
    {
        waitTime = patrolRoute.GetPatrolProperty(index).Delay; // Get delay from PatrolProperty
        index = (index + 1) % patrolRoute.GetWaypoints().Length; // Loop through waypoints
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("PatrolWaypoint"))
        {
            NextWaypoint();
        }
    }
    public void NextWaypoint()
    {
        patrolRoute.DisableWaypoint(index);
        handleWaypointCHange();
        patrolRoute.EnableWaypoint(index); // Enable the next waypoint
        enemyMovement.Standing(); // Stop moving when reaching a waypointz
    }
}
