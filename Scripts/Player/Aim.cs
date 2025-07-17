using UnityEngine;

public class Aim : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 where = Camera.main.ScreenToWorldPoint( Target.transform.position);
        Vector3 direction = gameObject.transform.position - where;
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
    }
}
