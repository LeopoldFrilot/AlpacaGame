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

    private void Update()
    {
        checkForClickTimer -= Time.deltaTime;
        if (checkForClickTimer <= 0f)
        {
            CheckForClick();
        }

        Vector2 scrollDelta = Input.mouseScrollDelta;
        if (scrollDelta != Vector2.zero)
        {
            EventHub.TriggerScroll(scrollDelta);
        }
    }

    private void CheckForClick()
    {
        bool found = false;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            EventHub.TriggerClickDown(ConvertMouseScreenToWorld(touch.position));
            found = true;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            EventHub.TriggerClickDown(ConvertMouseScreenToWorld(Input.mousePosition));
            found = true;
        }

        if (found)
        {
            checkForClickTimer = .2f;
        }
    }

    private Vector3 ConvertMouseScreenToWorld(Vector3 pos)
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        return mainCamera.ScreenToWorldPoint(pos);
    }
}
