using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IClickable
{
    void HandleClickDown(Vector2 clickLocation);
    bool WouldBeClicked(Vector2 clickLocation);
}
public class CropRoot : MonoBehaviour, IClickable
{
    public Collider2D clickCollider;
    public SpriteRenderer renderer;
    
    [SerializeField] private CropSO cropData;
    [SerializeField] private float growthTime;

    public void GrowFor(float timeInMinutes)
    {
        growthTime += timeInMinutes;
        int growthRank = Mathf.Clamp((int)growthTime / cropData.timeToGrowOneRankInMinutes, 0, cropData.growthSprites.Count * cropData.timeToGrowOneRankInMinutes);
        if (growthRank < cropData.growthSprites.Count)
        {
            renderer.sprite = cropData.growthSprites[growthRank];
        }
    }

    public void HandleClickDown(Vector2 clickLocation)
    {
        if (WouldBeClicked(clickLocation))
        {
            // Planting seed
            var seed = Player.Instance.selectedCropSeed;
            if (seed != null)
            {
                cropData = seed;
                growthTime = 0f;
                GrowFor(0f);
            }
        }
    }

    public bool WouldBeClicked(Vector2 clickLocation)
    {
        return clickCollider.bounds.Contains(clickLocation);
    }

    public bool IsSeeded()
    {
        return cropData != null;
    }
}
