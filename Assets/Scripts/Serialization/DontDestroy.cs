using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DontDestroy
{
    public static List<GameObject> _ddolObjects = new List<GameObject>();

    public static void Add(this GameObject go)
    {
        _ddolObjects.Add(go);
    }
    public static void DontDestroyThis(this GameObject go)
    {
        UnityEngine.Object.DontDestroyOnLoad(go);
        //_ddolObjects.Add(go);
    }

    public static void Delete(this GameObject go)
    {
        _ddolObjects.Remove(go);
    }

}
