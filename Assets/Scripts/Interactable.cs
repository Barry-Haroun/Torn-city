using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //add or remove an InteractionEvent component to this gameobject.
    public bool userEvents;
    //message displayed to player when looking at an interactable.
    [SerializeField] public string promptMessage;

    public virtual string onLook()
    {
        return promptMessage;
    }

    //this function will be called from our player.
    public void BaseInteract()
    {
        if (userEvents) 
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        Interact();
    }
    protected virtual void Interact()
    {
        //we wont have any code written in this function
        //this is a template function to be overridden by our subclasses
    }
}
