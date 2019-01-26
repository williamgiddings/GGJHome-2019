
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Generic3DButton : MonoBehaviour
{
    public List<UnityEvent> TriggerEvents;

    public void Interact(Transform ply)
    {
        foreach (UnityEvent Event in TriggerEvents)
        {
            Event.Invoke();
        }
    }

}