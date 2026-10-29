using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] float fallLimit = -10f;

    Rigidbody rb;
    Vector3 respawnPoint;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        respawnPoint = transform.position;
    }

    void Update()
    {
        if (transform.position.y < fallLimit) Respawn();
    }

    public void SetCheckpoint(Vector3 point) => respawnPoint = point;

    public void Respawn()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = respawnPoint;
    }
}