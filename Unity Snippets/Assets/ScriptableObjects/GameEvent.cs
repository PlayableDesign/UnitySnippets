using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Events/GameEvent")]
public class GameEvent : ScriptableObject
{
    public event Action<GameObject> OnEvent;

#if UNITY_EDITOR

    public List<string> Subscribers;

#endif

    public void Publish(GameObject sender)
    {

#if UNITY_EDITOR

        Subscribers = new List<string>();

        Delegate[] delegates = OnEvent?.GetInvocationList();

        if (delegates != null)
        {
            foreach (Delegate d in delegates)
            {
                if (d != null)
                {
                    var target = d.Target.ToString().Split();
                    var go = target[0];
                    var className = target[1].TrimStart('(').TrimEnd(')');

                    Subscribers.Add($"{go}:{className}:{d.Method.Name}");
                }
            }
        }
#endif


        OnEvent?.Invoke(sender);

    }




}
