
using Firebase.Analytics;
using UnityEngine;

public static class FB
{
    public static void LogTestEvent()
    {
        Debug.Log("LogTestEvent");
        FirebaseAnalytics.LogEvent("test_firebase_event", new Parameter("time_accessed", System.DateTime.Now.ToLongTimeString()));
    }
}
