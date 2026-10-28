using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset = new Vector3(0, 5, -8);
    [SerializeField] float smoothing = 5f;

    void LateUpdate()
    {
        Vector3 desired = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desired, smoothing * Time.deltaTime);
        transform.LookAt(target);
    }
}