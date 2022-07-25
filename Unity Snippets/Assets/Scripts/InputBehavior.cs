
using UnityEngine;
using UnityEngine.Events;

public class InputBehavior : MonoBehaviour
{
    [Header("Events")]
    [Space(10)]

    public UnityEvent<Vector3> OnInputMovement;
    public UnityEvent OnInputJump;

    private Vector3 _direction;

    private void OnEnable()
    {
        _direction = Vector3.zero;
    }

    private void Update()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        OnInputMovement.Invoke(_direction.normalized);

        if (Input.GetButton("Jump"))
        {
            OnInputJump.Invoke();
        }

    }

}
