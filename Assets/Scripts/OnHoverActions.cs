using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OnHoverAction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public UnityEvent onHoverEnter;
    public UnityEvent onHoverExit;
    private bool breakEvent;

    public void StopOnHovers()
    {
        breakEvent = true;
        gameObject.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!breakEvent)
        {
            onHoverEnter?.Invoke();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!breakEvent)
        {
            onHoverExit?.Invoke();
        }
    }
}