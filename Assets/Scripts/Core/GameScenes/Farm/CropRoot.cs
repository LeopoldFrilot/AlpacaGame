using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public interface IClickable
{
    void HandleClickDown(Vector2 clickLocation);
    bool WouldBeClicked(Vector2 clickLocation);
}
public class CropRoot : MonoBehaviour, IClickable
{
    public Collider2D clickCollider;
    public SpriteRenderer dirtRenderer;
    public SpriteRenderer cropRenderer;

    [SerializeField] private GeneralCropSO genCropData;
    private CropSO cropData;
    private float growthTime;
    private int growthRank;

    private void Start()
    {
        dirtRenderer.sprite = genCropData.dirtSprites[Random.Range(0, genCropData.dirtSprites.Count - 1)];
    }

    public void GrowFor(float timeInMinutes)
    {
        growthTime += timeInMinutes;
        growthRank = Mathf.Clamp((int)growthTime / cropData.timeToGrowOneRankInMinutes, 0, cropData.growthSprites.Count * cropData.timeToGrowOneRankInMinutes);
        if (growthRank < cropData.growthSprites.Count)
        {
            cropRenderer.sprite = cropData.growthSprites[growthRank];
        }
    }

    public void HandleClickDown(Vector2 clickLocation)
    {
        if (WouldBeClicked(clickLocation))
        {
            if (!IsSeeded())
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
            else
            {
                if (ReadyForHarvest())
                {
                    EventHub.TriggerCropHarvested(this);
                    growthTime = 0;
                    cropData = null;
                    cropRenderer.sprite = null;
                }
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

    public bool ReadyForHarvest()
    {
        return IsSeeded() && growthRank == cropData.growthSprites.Count - 1;
    }
}
