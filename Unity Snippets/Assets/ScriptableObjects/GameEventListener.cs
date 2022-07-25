
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{

    [Header("Settings")]

    [Tooltip("Assign a GameEvent ScriptableObject to subscribe to")]
    [SerializeField] private GameEvent gameEvent = default;

    [Tooltip("Assign one or more callback methods to be notified when the event is published")]
    [SerializeField] private UnityEvent<GameObject> OnGameEvent;

    // Unity Lifecycle

    private void OnEnable()
    {
        if (gameEvent != null)
            gameEvent.OnEvent += NotifySubscribers;
    }

    private void OnDisable()
    {
        if (gameEvent != null)
            gameEvent.OnEvent -= NotifySubscribers;
    }

    private void NotifySubscribers(GameObject sender)
    {
        OnGameEvent.Invoke(sender);
    }

}
