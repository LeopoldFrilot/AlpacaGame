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
}
