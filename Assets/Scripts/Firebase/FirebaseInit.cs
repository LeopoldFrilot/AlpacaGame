using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Analytics;
using Firebase.Extensions;
using UnityEngine;

public class FirebaseInit : MonoBehaviour
{
    #region Singleton
    private static FirebaseInit _instance;
    public static FirebaseInit Instance
    {
        get
        {
            if (!_instance)
            {
                GameObject gO = new GameObject("FirebaseInit");
                gO.AddComponent<FirebaseInit>().Awake();
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
    void Start()
    {
        FirebaseApp.CheckDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            var app = FirebaseApp.DefaultInstance;
        });
    }
}
