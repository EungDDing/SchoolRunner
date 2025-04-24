using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public void EnterButton()
    {
        GameManager.instance.AsyncLoadNextScene(SceneName.RunningScene);
    }
}
