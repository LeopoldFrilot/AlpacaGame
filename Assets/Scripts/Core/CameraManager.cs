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
    [SerializeField] private float panSensitivity = 1000f;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    public void MoveScreen(Vector2 delta)
    {
        transform.position = ClampPosition(transform.position + -(Vector3)delta * (Time.deltaTime * panSensitivity * (maxScreenSize - GetZoom()))/maxScreenSize);
    }

    public void ChangeZoomUsingDelta(float delta)
    {
        SetZoom(mainCamera.orthographicSize + delta);
    }

    public void SetZoom(float newZoom)
    {
        mainCamera.orthographicSize = Mathf.Clamp(newZoom, minScreenSize, maxScreenSize);
        transform.position = ClampPosition(transform.position);
    }

    private void HandleScroll(Vector2 delta)
    {
        ChangeZoomUsingDelta(-delta.y * Time.deltaTime * zoomSensitivity);
    }

    public float GetZoom()
    {
        return mainCamera.orthographicSize;
    }

    private Vector3 ClampPosition(Vector3 position)
    {
        float xExtent = (maxScreenSize - GetZoom()) * 16f / 9f;
        float yExtent = maxScreenSize - GetZoom();
        
        return new Vector3(
            Mathf.Clamp(position.x, -xExtent, xExtent),
            Mathf.Clamp(position.y, -yExtent, yExtent),
            position.z);
    }

    private void OnEnable()
    {
        EventHub.OnScroll += HandleScroll;
        EventHub.OnMiddleMouseDown += MoveScreen;
    }

    private void OnDisable()
    {
        EventHub.OnScroll -= HandleScroll;
        EventHub.OnMiddleMouseDown -= MoveScreen;
    }
}
