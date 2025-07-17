using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private EnemyShooting enemyShooting;
    void Start()
    {
        enemyShooting = gameObject.GetComponent<EnemyShooting>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Shoot()
    {
        enemyShooting.IsShooting = true;
    }
}
