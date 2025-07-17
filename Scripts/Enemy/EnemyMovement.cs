using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody rb;
    int movement;
    public float speed = 5f;
    public AnimationClip move;
    public AnimationClip Shoot;
    public AnimationClip Idle;
    EnemyShooting shooting;
    Vector3 direction;
    Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        shooting = GetComponent<EnemyShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        if (direction != Vector3.zero)
        {
            animator.Play(move.name);
        } else if (shooting.IsShooting == true)
        {
            animator.Play(Shoot.name);
        }
        else
        {
            animator.Play(Idle.name);
        }
    }

    private void FixedUpdate()
    {
        if (shooting.IsShooting == true)
            return;
        rb.linearVelocity = Vector3.zero; // Reset linear velocity to prevent sliding
        rb.angularVelocity = Vector3.zero; // Reset angular velocity to prevent spinning
        if (direction != Vector3.zero)
        {
            rb.MovePosition(rb.position + transform.forward * movement * speed * Time.deltaTime);
        }
       
    }

    public void MoveForward()
    {
        movement = 1;
        direction = transform.forward;
    }
    public void MoveBackward()
    {
        movement = -1;
        direction = -transform.forward;
    }

    public void Standing()
    {
        movement = 0;
        direction = Vector3.zero;
    }
}
