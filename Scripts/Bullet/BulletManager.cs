using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Bullet;
    private GameObject _bulletSpawner;
    public float SpawnRate = 0.5f;
    public float BulletSpeed = 500f;
    private float timeSinceLastFire;
    public float Spread = 5f;
    public Shoot _shootScript;
    void Start()
    {
        _bulletSpawner = GameObject.Find("Spawner");
    }

    private void OnEnable()
    {
        timeSinceLastFire = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if enough time has passed since the last fire
        if (Time.fixedTime - timeSinceLastFire >= SpawnRate)
        {
            // Clone and move the bullet
            CloneAndMove();
            if(_shootScript != null)
            {
                _shootScript.Shooting();
            }
            // Update the time of the last fire
            timeSinceLastFire = Time.fixedTime;
        }
    }

    Vector3 RandomizedDirection()
    {
        Vector3 randomizeDirection = Vector3.zero;
        randomizeDirection.y = UnityEngine.Random.Range(-Spread, Spread);
        randomizeDirection.z = UnityEngine.Random.Range(-Spread, Spread);
        return randomizeDirection;
    }
    void CloneAndMove()
    {
        // 1. Instantiate the clone
        GameObject clone = Instantiate(Bullet, Bullet.transform.position, Bullet.transform.rotation);
        Vector3 rad = RandomizedDirection();
        clone.transform.Rotate(rad.x, rad.y, rad.z, Space.Self);
        clone.SetActive(true);
        clone.transform.parent = _bulletSpawner.transform;
    }

}

