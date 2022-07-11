using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairScene : MonoBehaviour, IGameScene
{
    public SceneType GetSceneType()
    {
        return SceneType.Fair;
    }

    public void Initialize()
    {
        
    }
}
