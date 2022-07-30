using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "CropData", menuName = "ScriptableObjects/CropData", order = 1)]
public class CropSO : ScriptableObject
{
    public enum CropType
    {
        Tomato,
        Carrot,
        Potato,
        Wheat,

        // ALL NEW CROPS SHOULD GO ABOVE COUNT AND ORDER SHOULD NOT CHANGE
        Count
    }

    public CropType cropType;
    [FormerlySerializedAs("timeToGrowOneRank")] public int timeToGrowOneRankInMinutes;
    public List<Sprite> growthSprites = new List<Sprite>();
}
