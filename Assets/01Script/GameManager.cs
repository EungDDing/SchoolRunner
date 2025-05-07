using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public enum SceneName
{ 
    IntroScene,
    RunningScene,
    EndingScene
}

[System.Serializable]
public class EndingData
{
    public int endingID;
    public bool isUnlocked;
}
[System.Serializable]
public class PlayerData
{
    public string playerID;
    public List<EndingData> endings;
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int endingIndex;
    public int EndingIndex
    {
        get => endingIndex;
        set => endingIndex = value;
    }
    private PlayerData data;
    public PlayerData Data
    {
        get => data;
    }
    public void CreatePlayerData(string PlayerID)
    {
        data = new PlayerData();

        data.playerID = PlayerID;
        InitEndingData();
    }
    public void InitEndingData()
    {
        Debug.Log("Intialize player's ending list");

        data.endings = new List<EndingData>();

        foreach (var ending in DataManager.instance.GetAllEndingData())
        {
            EndingData_Entity endingDataValue = ending.Value;

            EndingData endingData = new EndingData();
            endingData.endingID = endingDataValue.EndingID;
            endingData.isUnlocked = false;

            data.endings.Add(endingData);
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        dataPath = Application.persistentDataPath + "/Save";
    }
    #region _SceneManager_
    private SceneName nextSceneName;
    public SceneName NextScene => nextSceneName;
    public void AsyncLoadNextScene(SceneName nextScene)
    {
        nextSceneName = nextScene;
        SceneManager.LoadScene(nextScene.ToString());
    }
    #endregion
    #region _Save&Load_
    private string dataPath;
    public void SaveData()
    {
        string playerData = JsonUtility.ToJson(data);
        File.WriteAllText(dataPath, playerData);
    }
    public bool LoadData()
    {
        if (File.Exists(dataPath))
        {
            string playerData = File.ReadAllText(dataPath);
            data = JsonUtility.FromJson<PlayerData>(playerData);
            return true;
        }
        return false;
    }
    public void DeleteData()
    {
        File.Delete(dataPath);
    }
    public bool TryGetPlayerData()
    {
        if (File.Exists(dataPath))
        {
            return LoadData();
        }
        return false;
    }
    #endregion
}
