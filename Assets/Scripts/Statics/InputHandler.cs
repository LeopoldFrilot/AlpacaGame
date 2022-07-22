using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    #region Singleton
    private static InputHandler _instance;
    public static InputHandler Instance
    {
        get
        {
            if (!_instance)
            {
                GameObject gO = new GameObject("InputHandler");
                gO.AddComponent<InputHandler>().Awake();
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
            DontDestroyOnLoad(_instance.gameObject);
        }
    }
    #endregion

    private Camera mainCamera;

    private float checkForClickTimer = 0f;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        checkForClickTimer -= Time.deltaTime;
        if (checkForClickTimer <= 0f)
        {
            CheckForClick();
        }
        
    }

    private void CheckForClick()
    {
        bool found = false;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            EventHub.TriggerOnClickDown(ConvertMouseScreenToWorld(touch.position));
            found = true;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            EventHub.TriggerOnClickDown(ConvertMouseScreenToWorld(Input.mousePosition));
            found = true;
        }

        if (found)
        {
            checkForClickTimer = .1f;
        }
    }

    private Vector3 ConvertMouseScreenToWorld(Vector3 pos)
    {
        return mainCamera.ScreenToWorldPoint(pos);
    }
}
