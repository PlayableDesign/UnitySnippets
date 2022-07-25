
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyMovementBehavior : MonoBehaviour
{

    [Header("Settings")]
    [Space(10)]

    [Tooltip("Set the speed used to move the Rigidbody")]
    [SerializeField] private float speed;

    [Tooltip("Set the drag used by the Rigidbody")]
    [SerializeField] private float drag;

    [Tooltip("Account for mass when applying force to the Rigidbody")]
    [SerializeField] private bool useMass;

    [Tooltip("Enable to rotate towards the direction moving in")]
    [SerializeField] private bool faceMoveDirection;

    // Private state

    private Rigidbody _rb;
    private RigidbodyConstraints _constraints;

    private Vector3 _direction;
    private bool _grounded;

    // Unity Lifecycle

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _constraints = _rb.constraints;
        _rb.drag = drag;
    }

    private void Update()
    {
        if (faceMoveDirection && _direction != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(-(_direction));
    }

    private void FixedUpdate()
    {
        if (useMass)
        {
            // continous / mass
            _rb.AddForce(_direction * speed, ForceMode.Impulse);
        }
        else
        {
            //continuous / no mass
            _rb.AddForce(_direction * speed, ForceMode.VelocityChange);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        _grounded = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        _grounded = false;
    }

    // Public API

    public void Move(Vector3 direction)
    {
        _direction = direction;
    }

    public void MoveRandom()
    {
        var x = Random.Range(-1.0f, 1.0f);
        var y = transform.position.y;
        var z = Random.Range(-1.0f, 1.0f);
        Vector3 direction = new(x, y, z);
        _direction = direction;
    }

    public void Stop()
    {
        _direction = Vector3.zero;
        _rb.velocity = Vector3.zero;
    }

    public void Jump()
    {
        if (_grounded)
        {
            _grounded = false;
            _rb.velocity = new(_rb.velocity.x, speed, _rb.velocity.z);

        }
    }

    public void FreezeAll()
    {
        _rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void FreezePosition()
    {
        _rb.constraints = RigidbodyConstraints.FreezePosition;
    }

    public void FreezeRotation()
    {
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    public void UnFreeze()
    {
        _rb.constraints = _constraints;
    }

}
