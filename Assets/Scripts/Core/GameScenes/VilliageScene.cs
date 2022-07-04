using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VilliageScene : MonoBehaviour, IGameScene
{
    public SceneType GetSceneType()
    {
        return SceneType.Villiage;
    }

    public void Initialize()
    {
        throw new System.NotImplementedException();
    }
}
