using UnityEngine;
using BNG;

public class DisableDropOnGrab : MonoBehaviour
{
    public void DisableDrop()
    {
        gameObject.GetComponent<Grabbable>().CanBeDropped = false;
    }

    public void EnableDrop()
    {
        gameObject.GetComponent<Grabbable>().CanBeDropped = true;
    }
}
