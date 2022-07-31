using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class AlpacaIUController : MonoBehaviour
{
    public GameObject closeupUI;
    public Transform topHeartHolder;
    public Transform bottomHeartHolder;
    public TextMeshProUGUI alpacaLevelText;
    public GameObject emptyHeartPrefab;
    public GameObject fullheartPrefab;

    [SerializeField] private int closeupZoomThreshold = 45;
    private bool zoomUpdate;

    private void LateUpdate()
    {
        if (zoomUpdate)
        {
            closeupUI.SetActive(closeupZoomThreshold >= CameraManager.Instance.GetZoom());
            zoomUpdate = false;
        }
    }

    private void HandleScroll(Vector2 unused)
    {
        zoomUpdate = true;
    }
    
    private void OnEnable()
    {
        EventHub.OnScroll += HandleScroll;
    }
    
    private void OnDisable()
    {
        EventHub.OnScroll -= HandleScroll;
    }
}
