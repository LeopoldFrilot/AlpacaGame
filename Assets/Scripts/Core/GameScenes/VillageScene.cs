using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageScene : MonoBehaviour, IGameScene
{
    public SceneType GetSceneType()
    {
        return SceneType.Village;
    }

    public void Initialize()
    {
        throw new System.NotImplementedException();
    }
}
