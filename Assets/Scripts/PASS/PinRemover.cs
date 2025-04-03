using UnityEngine;
using UnityEngine.Events;

public class PinRemover : MonoBehaviour
{
    public float timer;
    public UnityEvent onPinDisabled;

    public void DisablePin()
    {
        StartCoroutine(disablePin());
    }
    System.Collections.IEnumerator disablePin()
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
        onPinDisabled.Invoke();
    }
}
