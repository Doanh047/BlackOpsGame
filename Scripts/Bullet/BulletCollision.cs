using System;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float? _timeSinceHit = null;
    public GameObject[] DisableWhenHitWall;
    public GameObject[] EnableWhenHitWall;
    public float DestroyDelay = 2f; // Time before the bullet is destroyed after hitting an object
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_timeSinceHit != null && Time.fixedTime - _timeSinceHit > DestroyDelay)
        {
            Destroy(gameObject);
        } else if (_timeSinceHit!=null && Time.fixedTime - _timeSinceHit <= DestroyDelay)
        {
            foreach (GameObject gameObject in DisableWhenHitWall)
            {
                // Disable the specified objects when the bullet hits a wall
                if(gameObject != null) // Check if the gameObject is not null
                    gameObject.SetActive(false);
            }
            foreach (GameObject gameObject in EnableWhenHitWall)
            {
                // Enable the specified objects when the bullet hits a wall
                if (gameObject != null) // Check if the gameObject is not null
                    gameObject.SetActive(true);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the bullet collided with an object tagged as "Enemy"
        if (collision.gameObject.name == "Enemy")
        {
            // Destroy the enemy object
            Destroy(collision.gameObject);
            // Optionally, destroy the bullet itself
            Destroy(gameObject);
        }
        else if (collision.transform.name == "Wall")
        {
            // Destroy the bullet when it hits a wall
            _timeSinceHit = Time.fixedTime; // Record the time of the hit
        }
    }


}
