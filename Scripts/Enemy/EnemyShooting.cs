using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyShooting : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool IsShooting = false;
    public bool HasSeenPlayer = false;
    public bool Chase = false;
    private GameObject Player;
    public float DetectionAngle = 60f; // Angle to detect the player
    public float DetectionDistance = 30f; // Distance to detect the player
    public GameObject[] ObjectToEnable;

    void Start()
    {
        Player = GameObject.Find("Player_Mesh");
    }

    // Update is called once per frame
    void Update()
    {
        if (IsShooting && ObjectToEnable[0].activeSelf == false)
        {
            foreach (var obj in ObjectToEnable)
            {
                if (obj != null)
                {
                    obj.SetActive(true);
                }
            }
        }
        else if (!IsShooting && ObjectToEnable[0].activeSelf == true)
        {
            foreach (var obj in ObjectToEnable)
            {
                if (obj != null)
                {
                    obj.SetActive(false);
                }
            }
        }
        if (Player == null || HasSeenPlayer == false)
            return;
        Vector3 direction = Player.transform.position - transform.position;
        Vector3 origin = transform.position;
        origin.y = origin.y + 2f;
        Ray ray = new Ray(origin, direction);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, DetectionDistance)) // 100 = max distance
        {
            if (hit.collider.gameObject.name.Contains("Player"))
            {
                // Player is in sight, start shooting
                IsShooting = true;
                Aim();
                if (Physics.Raycast(ray, out _, DetectionDistance / 2) == false)
                {
                    Chase = true;
                } else if (Physics.Raycast(ray, out _, DetectionDistance * 3 / 4))
                {
                    Chase = false; // Player is in sight, start chasing
                }
                
            }
            else
            {
                // Player is not in sight, stop shooting
                IsShooting = false;
            }

        }
        // Debug line
        if (!Chase)
        {
            Debug.DrawRay(origin, direction * 10, Color.green);
        }
        else
        {
            Debug.DrawRay(origin, direction * 10, Color.red);
        }
    }

    private void Aim()
    {
        if (Player == null)
            return;
        Vector3 where = Player.transform.position;
        Vector3 direction = where - gameObject.transform.position;
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
    }

    private void FixedUpdate()
    {
        CheckPlayerInSight();
    }
    private void CheckPlayerInSight()
    {
        if(Player.activeSelf == false)
        {
            HasSeenPlayer = false;
            IsShooting = false;
            Chase = false;
            return; // Player is not active, exit early
        }
        // Direction the player is facing
        Vector3 playerForward = Player.transform.position - transform.position;

        // Target direction (can also be a direction toward another object)
        Vector3 targetDirection = transform.forward; // global forward (0, 0, 1)

        // Calculate the angle between the directions
        float angle = Vector3.Angle(playerForward, targetDirection);
        float distance = Vector3.Distance(Player.transform.position, transform.position);
        if (DetectionAngle > angle && DetectionDistance > distance)
        {
            HasSeenPlayer = true;
        }
        else
        {
            HasSeenPlayer = false;
            IsShooting = false;
            Chase = false;
        }
    }
}
