using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody rb;
    int movement;
    public float speed = 5f;
    public AudioSource moveAudioSource;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (moveAudioSource == null)
            moveAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal and vertical input axes
        float vertical = Input.GetAxis("Vertical");
        // Create a movement vector based on input
        //if (vertical < 0)
        //    vertical = 0;
        if (vertical > 0)
            movement = 1;
        else if (vertical < 0)
            movement = -1;
        else
            movement = 0;

        
        if (movement != 0)
        {
            if (!moveAudioSource.isPlaying)
                moveAudioSource.Play();
        }
        else
        {
            if (moveAudioSource.isPlaying)
                moveAudioSource.Pause(); //
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = Vector3.zero; // Reset linear velocity to prevent sliding
        rb.angularVelocity = Vector3.zero; // Reset angular velocity to prevent spinning
        rb.MovePosition(rb.position + transform.forward * movement * speed * Time.deltaTime);
    }
}
