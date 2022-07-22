using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper
{
    public static float MinutesToSeconds(float minutes)
    {
        return minutes * 60f;
    }

    public static float SecondsToMinutes(float seconds)
    {
        return seconds / 60f;
    }
    
    public static T SafeDestroy<T>(T obj) where T : Object
    {
        if (Application.isEditor)
            Object.DestroyImmediate(obj);
        else
            Object.Destroy(obj);
     
        return null;
    }
    public static T SafeDestroyGameObject<T>(T component) where T : Component
    {
        if (component != null)
            SafeDestroy(component.gameObject);
        return null;
    }
}
