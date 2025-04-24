using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public enum SceneName
{ 
    IntroScene,
    RunningScene
}

[System.Serializable]
public class PlayerData
{
    public string playerID;

}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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
    }
    
    #region _SceneManager_
    private SceneName nextSceneName;
    public SceneName NextScene => nextSceneName;
    public void AsyncLoadNextScene(SceneName nextScene)
    {
        nextSceneName = nextScene;
        SceneManager.LoadScene(SceneName.RunningScene.ToString());
    }
    #endregion
}
