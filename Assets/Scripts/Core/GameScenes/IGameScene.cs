using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneType
{
    None,
    Farm,
    Villiage,
    Fair
}
public interface IGameScene
{
    public SceneType GetSceneType();
    void Initialize();
}
