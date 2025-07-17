using UnityEngine;

public class AnimationController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Animator animator = GetComponent<Animator>();
        float z = Input.GetAxis("Vertical");
        if (z > 0)
            animator.Play("demo_combat_run");
        else if (z < 0)
        {
            animator.Play("demo_combat_run_backward");

        }
        else if (z == 0)
            animator.Play("demo_combat_idle");

    }
}
