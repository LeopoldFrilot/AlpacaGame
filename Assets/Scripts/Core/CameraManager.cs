using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class CameraManager : MonoBehaviour
{
    #region Singleton
    private static CameraManager _instance;
    public static CameraManager Instance
    {
        get
        {
            if (!_instance)
            {
                GameObject gO = new GameObject("Player");
                gO.AddComponent<CameraManager>().Awake();
            }
            return _instance;
        }
    }


    public void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    [SerializeField] private int maxScreenSize = 540;
    [SerializeField] private int minScreenSize = 10;
    [SerializeField] private float zoomSensitivity = 2000f;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    public void MoveScreen(Vector3 delta)
    {
        transform.position += delta;
    }

    public void ChangeZoomUsingDelta(float delta)
    {
        SetZoom(mainCamera.orthographicSize + delta);
    }

    public void SetZoom(float newZoom)
    {
        mainCamera.orthographicSize = Mathf.Clamp(newZoom, minScreenSize, maxScreenSize);
    }

    private void HandleScroll(Vector2 delta)
    {
        ChangeZoomUsingDelta(-delta.y * Time.deltaTime * zoomSensitivity);
    }

    public float GetZoom()
    {
        return mainCamera.orthographicSize;
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
