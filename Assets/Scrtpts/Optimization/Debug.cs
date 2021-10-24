using UnityEngine;

public static class Debug 
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void Log(object message) => UnityEngine.Debug.Log(message);
    
}
