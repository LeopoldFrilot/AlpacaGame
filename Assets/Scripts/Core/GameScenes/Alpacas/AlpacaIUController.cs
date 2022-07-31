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

    private void HandleScroll(Vector2 unused)
    {
        closeupUI.SetActive(closeupZoomThreshold >= CameraManager.Instance.GetZoom());
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
