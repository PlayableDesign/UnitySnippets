
using UnityEngine;

public class RigidBodyMovementAsset : ScriptableObject
{
    public ForceMode Mode;

    public void MoveOnFixedUpdate(Rigidbody body, Vector3 force)
    {
        body.AddForce(force, Mode);
    }

}

// Drag (Air Resistance)  0(none), 0.001 (heavy) -> 10 (feather), infinity (no movement)


// AngularDrag, rotation from torque, 
// 0 = none
// infinity, You cannot make an object stop rotating just by setting its Angular Drag to infinity.

// gravity on/off

// kinematic - not controlled by physics

// Interpolate - handle jerkiness
// none, Interpolate (last frame transform), Extrapolate (predicted transform)


// Collision Detection

// Constraints



// Mass, doesn't affect falling speed, determines collision (KG)
// Physics material - friction and bounce
// Scale affects physics


// Manual https://docs.unity3d.com/Manual/PhysicsOverview.html

