using UnityEngine;

public class GizmoBehavior : MonoBehaviour
{
    void OnDrawGizmos()
    {
#if UNITY_EDITOR
        UnityEditor.Handles.color = Color.white;
        UnityEditor.Handles.Label(transform.position, "Pos: ");
#endif
    }
}
