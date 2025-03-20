using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using BNG;

public class ObjectSnapper : MonoBehaviour
{
    public GameObject Object;

    private bool eventCalled;
    private bool objectCollided;
    public bool eventCompleted;

    public UnityEvent onPlacementStart;
    public UnityEvent onObjectGrabbed;
    public UnityEvent onObjectSnapped;
    public UnityEvent AfterObjectSnapped;

    public void StartPlacement()
    {
        gameObject.GetComponent<Collider>().enabled = true;
        Object.GetComponent<Collider>().enabled = true;
        gameObject.GetComponent<SnapZone>().enabled = true;
        if (Object.GetComponent<Grabbable>().enabled == false)
        {
            Object.GetComponent<Grabbable>().enabled = true;
        }
        onPlacementStart.Invoke();
        eventCalled = true;
    }

    public void OnObjectGrab()
    {
        if (eventCalled && !eventCompleted)
        {
            onObjectGrabbed.Invoke();
            Object.GetComponent<Grabbable>().CanBeDropped = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (eventCalled && other.gameObject == Object && !eventCompleted)
        {
            gameObject.GetComponent<SnapZone>().GrabGrabbable(Object.GetComponent<Grabbable>());
            Object.GetComponent<Grabbable>().CanBeDropped = true;
            onObjectSnapped.Invoke();
            objectCollided = true;
        }
    }

    public void AfterObjectSnap()
    {
        if (eventCalled && objectCollided && !eventCompleted)
        {
            gameObject.GetComponent<SnapZone>().GrabGrabbable(Object.GetComponent<Grabbable>());
            gameObject.GetComponent<Collider>().enabled = false;
            Object.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<SnapZone>().enabled = false;
            AfterObjectSnapped.Invoke();
            eventCompleted = true;
        }
    }

    public void AutoCompleteSnap()
    {
        //Rather Than Snapping We have Used the Transform To Place The Object to Avoid Parenting Of The Object
        Object.transform.position = gameObject.transform.position;
        Object.transform.rotation = gameObject.transform.rotation;
        Object.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<SnapZone>().enabled = false;
        eventCompleted = true;
    }
}
