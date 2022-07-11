using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmScene : MonoBehaviour, IGameScene
{
    public SceneType GetSceneType()
    {
        return SceneType.Farm;
    }

    public void Initialize()
    {
        
    }
}
