using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class CompletedSceneManager : MonoBehaviour
{
    public static int completedScene;
    public UnityEvent onAllScenesCompleted;
    public bool skipStep;

    private void Start()
    {
        /*if(skipStep)
        {
            completedScene = 4;
        }

        if (completedScene == 4)
        {
            Debug.Log("All Scenes Completed");
            onAllScenesCompleted.Invoke();
        }*/
    }
    public void SceneCompleted()
    {
        completedScene++;
        Debug.Log(completedScene);
    }
}
