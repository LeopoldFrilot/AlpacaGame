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
    private Vector3 lastMousePosition;
    private float checkForClickTimer = 0f;

    private Touch touch0;
    private Touch touch1;
    private int touchCount;
    private Vector3 lastTouch1Position;

    private void Update()
    {
        touchCount = Input.touchCount;
        if (touchCount > 0)
        {
            touch0 = Input.GetTouch(0);
            if (touchCount > 1)
            {
                touch1 = Input.GetTouch(1);
            }
        }
        
        checkForClickTimer -= Time.deltaTime;
        if (checkForClickTimer <= 0f)
        {
            CheckForClickDown();
        }

        if (touchCount > 1)
        {
            EventHub.TriggerScroll(new Vector2(0,
                Vector3.Distance(touch0.position, touch1.position) - Vector3.Distance(lastMousePosition, lastTouch1Position)));
        }
        else if (Input.mouseScrollDelta != Vector2.zero)
        {
            EventHub.TriggerScroll(Input.mouseScrollDelta);
        }

        if (touchCount > 1)
        {
            EventHub.TriggerMiddleMouseDown((touch0.position + touch1.position) / 2f - (Vector2)(lastMousePosition + lastTouch1Position) / 2f);
        }
        else if (Input.GetKey(KeyCode.Mouse2))
        {
            EventHub.TriggerMiddleMouseDown(Input.mousePosition - lastMousePosition);
        }

        if (touchCount > 0)
        {
            lastMousePosition = touch0.position;
            if (touchCount > 1)
            {
                lastTouch1Position = touch1.position;
            }
        }
        else
        {
            lastMousePosition = Input.mousePosition;
        }
    }

    private void CheckForClickDown()
    {
        bool found = false;
        if (touchCount > 0)
        {
            EventHub.TriggerClickDown(ConvertMouseScreenToWorld(touch0.position));
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
