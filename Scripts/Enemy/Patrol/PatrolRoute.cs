using UnityEngine;

public class PatrolRoute : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Transform[] waypoints;
    PatrolProperty[] patrolProperties;
    void Start()
    {
        waypoints = GetComponentsInChildren<Transform>();
        // Exclude the parent object from the waypoints
        waypoints = System.Array.FindAll(waypoints, wp => wp != transform);
        patrolProperties = GetComponentsInChildren<PatrolProperty>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public Transform GetWaypoint(int index)
    {

        return waypoints[index];
    }
    public Transform[] GetWaypoints()
    {
        return waypoints;
    }
    public void DisableWaypoint(int index)
    {
        waypoints[index].gameObject.SetActive(false); // Disable the waypoint GameObject
    }
    public void EnableWaypoint(int index)
    {
        waypoints[index].gameObject.SetActive(true); // Disable the waypoint GameObject
    }
    public PatrolProperty GetPatrolProperty(int index)
    {
        return patrolProperties[index];
    }
}
