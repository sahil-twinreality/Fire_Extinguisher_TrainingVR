using UnityEngine;

public class PinRemover : MonoBehaviour
{
    public float timer;

    public void DisablePin()
    {
        StartCoroutine(disablePin());
    }
    System.Collections.IEnumerator disablePin()
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }
}
