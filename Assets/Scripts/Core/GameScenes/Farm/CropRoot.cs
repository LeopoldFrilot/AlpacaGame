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
        growthRank = Mathf.Clamp((int)growthTime / cropData.timeToGrowOneRankInMinutes, 0, cropData.growthSprites.Count - 1);
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
                var seed = Player.Instance.GetSelectedCropSeed();
                if (seed != null && Player.Instance.GetSeedCount(seed.cropType) > 0)
                {
                    cropData = seed;
                    growthTime = 0f;
                    GrowFor(0f);
                    Player.Instance.ChangeSeedCount(seed, -1);
                }
            }
            else
            {
                if (ReadyForHarvest())
                {
                    EventHub.TriggerCropHarvested(this);
                    Player.Instance.ChangeSeedCount(cropData, 1);
                    Player.Instance.CoinChange(cropData.cropType == CropSO.CropType.Wheat ? 25 : 500);
                    EventHub.TriggerCropSeedCountChanged(cropData);
                    growthTime = 0;
                    cropData = null;
                    cropRenderer.sprite = null;
                }
            }
        }
    }

    public CropSO.CropType GetCropType()
    {
        return cropData.cropType;
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
