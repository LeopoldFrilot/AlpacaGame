using System;
using System.Collections.Generic;
using UnityEngine;

public class FarmScene : MonoBehaviour, IGameScene
{
    [SerializeField] private GameObject cropPrefab;
    private List<NonInteractionZones> nonIntZones = new List<NonInteractionZones>();
    private List<CropRoot> cropRoots = new List<CropRoot>();
    public SceneType GetSceneType()
    {
        return SceneType.Farm;
    }

    public void Initialize()
    {
        foreach (var cropRoot in FindObjectsOfType<CropRoot>())
        {
            cropRoots.Add(cropRoot);
        }
        foreach (var zone in FindObjectsOfType<NonInteractionZones>())
        {
            Debug.Log(zone);
            nonIntZones.Add(zone);
        }
    }

    public void HandleClick(Vector2 worldPos)
    {
        foreach (var zone in nonIntZones)
        {
            if (zone.collider != null && zone.gameObject.activeSelf && zone.collider.bounds.Contains(worldPos))
            {
                return;
            }
        }
        
        bool cropFound = false;
        foreach (var crop in cropRoots)
        {
            if (crop.WouldBeClicked(worldPos))
            {
                crop.HandleClickDown(worldPos);
                cropFound = true;
                break;
            }
        }

        if (!cropFound)
        {
            TillSoil(worldPos);
        }
    }

    private void TillSoil(Vector2 worldPos)
    {
        GameObject newCrop = Instantiate(cropPrefab, worldPos, cropPrefab.transform.rotation, this.transform);
        CropRoot cropRoot = newCrop.GetComponent<CropRoot>();
        if (cropRoot != null)
        {
            cropRoots.Add(cropRoot);
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

    private void OnEnable()
    {
        EventHub.OnPomodoroEnded += GrowCropsBy;
    }

    private void OnDisable()
    {
        EventHub.OnPomodoroEnded -= GrowCropsBy;
    }
}
