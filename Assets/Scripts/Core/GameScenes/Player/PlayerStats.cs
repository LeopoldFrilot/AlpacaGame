using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
    public PlayerStats(int coins, int soles, int startingWheatCount, int startingTomatoCount)
    {
        this.coins = coins;
        this.soles = soles;

        seedCount = new int[(int)CropSO.CropType.Count];
        seedCount[(int)CropSO.CropType.Wheat] = startingWheatCount;
        seedCount[(int)CropSO.CropType.Tomato] = startingTomatoCount;

        harvestedCount = new int[(int)CropSO.CropType.Count];
    }

    public int coins;
    public int soles;
    public int[] seedCount; 
    public int[] harvestedCount;

    public void HarvestCrop(CropSO.CropType cropType, int quantity)
    {
        harvestedCount[(int)cropType] += quantity;
    }

    public int GetSeedCount(CropSO.CropType cropType)
    {
        return seedCount[(int)cropType];
    }

    public void ChangeSeedCount(CropSO.CropType cropType, int delta)
    {
        seedCount[(int)cropType] += delta;
    }
}
