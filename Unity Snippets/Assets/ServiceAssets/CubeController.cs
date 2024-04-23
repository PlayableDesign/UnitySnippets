
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeController : MonoBehaviour
{

    private Rigidbody body;
    private Vector3 direction;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        direction = Vector3.zero;
    }

    private void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        direction.Normalize(); //handle diagonal scale
    }

    private void FixedUpdate()
    {
        if (direction == Vector3.zero) return;

        // Add code to move the RigidBody
    }
}
