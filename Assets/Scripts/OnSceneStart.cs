using UnityEngine;
using UnityEngine.Events;

public class OnSceneStart : MonoBehaviour
{
    public UnityEvent onSceneBegin;

    private void Start()
    {
        onSceneBegin.Invoke();
    }
}
