using System;
using System.Collections.Generic;
using UnityEngine;

public class FarmScene : MonoBehaviour, IGameScene
{
    private enum CropGridStatus
    {
        Null,
        Tilled,
        Seeded
    }
    
    [SerializeField] private GameObject cropPrefab;
    [SerializeField] private List<NonInteractionZones> nonIntZones = new();
    
    public GridManager cropGridManager;
    public PomodoroManager pomodoroManager;
    
    private List<CropRoot> cropRoots = new();
    private bool initialized = false;

    public void Initialize()
    {
        if (!initialized)
        {
            foreach (var cell in cropGridManager.GetAllCells())
            {
                HandleClick(cropGridManager.GetWorldPosition(cell.x, cell.y, true));
            }

            initialized = true;
        }
    }
    
    public SceneType GetSceneType()
    {
        return SceneType.Farm;
    }

    public void HandleClick(Vector2 worldPos)
    {
        if (pomodoroManager.GetState() == PomodoroState.Pomodoro)
            return;
        
        if (cropGridManager.ValidGridClick(worldPos))
        {
            foreach (var zone in nonIntZones)
            {
                if (zone.collider != null && zone.gameObject.activeSelf && zone.collider.bounds.Contains(worldPos))
                {
                    return;
                }
            }
            
            switch ((CropGridStatus)cropGridManager.GetValue(worldPos))
            {
                case CropGridStatus.Null:
                    TillSoil(worldPos);
                    break;
                
                default:
                    foreach (CropRoot crop in cropRoots)
                    {
                        if (crop.WouldBeClicked(worldPos))
                        {
                            crop.HandleClickDown(worldPos);
                            cropGridManager.UpdateGridValue(worldPos, (int)(crop.IsSeeded() ? CropGridStatus.Seeded : CropGridStatus.Tilled));
                            break;
                        }
                    }
                    break;
            }
        }
        
    }

    private void TillSoil(Vector2 worldPos)
    {
        GameObject newCrop = Instantiate(cropPrefab, worldPos, cropPrefab.transform.rotation, this.transform);
        CropRoot cropRoot = newCrop.GetComponent<CropRoot>();
        if (cropRoot != null)
        {
            AddCrop(cropRoot);
        }
        else
        {
            Destroy(newCrop);
        }
    }

    private void GrowCropsBy(float timeInMinutes)
    {
        foreach (var cropRoot in cropRoots)
        {
            if (cropRoot.IsSeeded())
            {
                cropRoot.GrowFor(timeInMinutes);
            }
        }
    }
    
    private void AddCrop(CropRoot cropRoot)
    {
        if (!cropRoots.Contains(cropRoot))
        {
            cropRoots.Add(cropRoot);
            if (cropGridManager.SnapToGrid(cropRoot.transform))
            {
                cropGridManager.UpdateGridValue(cropRoot.transform.position, (int)(cropRoot.IsSeeded() ? CropGridStatus.Seeded : CropGridStatus.Tilled));
            }  
        }
    }

    private void HarvestCrop(CropRoot crop)
    {
        cropGridManager.UpdateGridValue(crop.transform.position, (int)CropGridStatus.Tilled);
    }

    private void OnEnable()
    {
        EventHub.OnPomodoroEnded += GrowCropsBy;
        EventHub.OnCropHarvested += HarvestCrop;
    }

    private void OnDisable()
    {
        EventHub.OnPomodoroEnded -= GrowCropsBy;
        EventHub.OnCropHarvested -= HarvestCrop;
    }
}
