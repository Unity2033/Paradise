using System;
using UnityEngine;

public static class Debug 
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void Log(object message) => UnityEngine.Debug.Log(message);

    internal static void LogWarning(string v)
    {
        throw new NotImplementedException();
    }
}
