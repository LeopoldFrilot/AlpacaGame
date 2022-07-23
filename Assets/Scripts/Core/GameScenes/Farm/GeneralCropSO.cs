using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GeneralCropData", menuName = "ScriptableObjects/GeneralCropData", order = 1)]
public class GeneralCropSO : ScriptableObject
{
    public List<Sprite> dirtSprites = new();
    public List<Sprite> wetDirtSprites = new();
}
