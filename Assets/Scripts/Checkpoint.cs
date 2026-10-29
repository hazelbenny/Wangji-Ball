using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerRespawn player))
            player.SetCheckpoint(transform.position + Vector3.up);
    }
}