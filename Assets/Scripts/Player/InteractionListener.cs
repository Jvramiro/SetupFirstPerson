using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionListener : MonoBehaviour, IInteraction
{
    public UnityEvent onInteract;
    public void Interact(){
        onInteract?.Invoke();
    }
}
