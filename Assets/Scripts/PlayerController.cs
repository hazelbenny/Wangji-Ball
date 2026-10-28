using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveForce = 10f;
    [SerializeField] float jumpForce = 6f;
    [SerializeField] float groundCheckDistance = 0.6f;

    Rigidbody rb;
    Transform cam;
    bool jumpRequested;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump")) jumpRequested = true;
    }

    void FixedUpdate()
    {
        Vector3 forward = Vector3.ProjectOnPlane(cam.forward, Vector3.up).normalized;
        Vector3 right = Vector3.ProjectOnPlane(cam.right, Vector3.up).normalized;
        Vector3 dir = forward * Input.GetAxis("Vertical") + right * Input.GetAxis("Horizontal");
        rb.AddForce(dir * moveForce);

        if (jumpRequested && Physics.Raycast(transform.position, Vector3.down, groundCheckDistance))
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        jumpRequested = false;
    }
}