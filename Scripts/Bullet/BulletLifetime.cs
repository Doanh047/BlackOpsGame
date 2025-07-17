using UnityEngine;

public class BulletLifetime : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float LifeTime = 10f;
    private float _startTime;
    void Start()
    {

    }

    private void OnEnable()
    {
        _startTime = Time.fixedTime;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.fixedTime - _startTime > LifeTime)
        {
            // Destroy the bullet after its lifetime has expired
            Destroy(gameObject);
        }
    }
}
