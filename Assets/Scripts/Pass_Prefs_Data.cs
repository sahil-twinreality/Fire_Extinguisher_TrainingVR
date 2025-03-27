using UnityEngine;

public class Pass_Prefs_Data : MonoBehaviour
{
    private string prefsName;
    public void SaveData(string prefSaveName)
    {
        prefsName = prefSaveName;
        PlayerPrefs.SetInt(prefSaveName + "_eventCompleted", 1);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt(prefSaveName + "_eventCompleted", 0));
    }
}
