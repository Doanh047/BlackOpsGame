using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float Speed = 100.0f;
    public GameObject StopWhenDisabled;
    private Rigidbody rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(StopWhenDisabled.activeSelf == false)
        {
            // If the StopWhenDisabled GameObject is not active, stop the bullet movement
            return;
        }
        rb.MovePosition(rb.position + transform.forward * Speed * Time.deltaTime);
    }
}
