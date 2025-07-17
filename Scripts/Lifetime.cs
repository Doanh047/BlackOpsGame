using UnityEngine;

public class LifeTime : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float Lifetime = 1.0f;
    private float _timeSinceActive;
    void Start()
    {
        
    }
    private void OnEnable()
    {
        _timeSinceActive = Time.fixedTime;
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.fixedTime - _timeSinceActive >= Lifetime)
        {
            // Destroy the game object after the specified lifetime
            Destroy(gameObject);
        }
    }
}
