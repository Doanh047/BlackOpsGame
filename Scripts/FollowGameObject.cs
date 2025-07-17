using UnityEngine;

public class FollowGameObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Target.transform.position.x, this.transform.position.y, Target.transform.position.z);
    }
}
