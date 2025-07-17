using JetBrains.Annotations;
using UnityEngine;

public class PatrolProperty : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector3 Rotate = Vector3.zero;
    public float Delay = 1f;
    private Vector3 originalPosition;
    private Vector3 originalRotation;
    private Rigidbody rb;
    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.eulerAngles;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != transform.parent.parent?.gameObject)
            return;
            // Handle player entering the trigger area
            gameObject.SetActive(false);
    }

    private void LateUpdate()
    {
        transform.position = originalPosition;
        transform.rotation = Quaternion.Euler(originalRotation + Rotate);
    }
}
