using UnityEngine;

public class Pass_Prefs_Data : MonoBehaviour
{
    private string prefsName;

    public static Pass_Prefs_Data Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SaveData(string prefSaveName)
    {
        PlayerData.Instance.SaveData(prefSaveName);
    }
}
