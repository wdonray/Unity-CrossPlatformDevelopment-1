using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.Assertions;

public class ScriptableSingleton<T> : ScriptableObject where T : ScriptableObject
{
    protected static T _instance;

    public static T Instance
    {
        get
        {
            if (!_instance)
                _instance = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault();
            if(!_instance)
                _instance = CreateInstance<T>();
            return _instance;
        }
    }
}

/// <summary>
/// class to track data and save to a location
/// </summary>
[CreateAssetMenu]
public class DataController : ScriptableSingleton<DataController>
{
    private static string path;

    private void OnEnable()
    {
        //should be replaced with Application.persistentDataPath
        path = Application.dataPath + "/Saves/";
        Debug.Log(path);
    }

    public static void Save<T>(T data) where T : ScriptableObject
    {
        Debug.LogFormat("save {0} with filename {0}.json", data);
        //object to json string
        var json = JsonUtility.ToJson(data, true);
        //filename to save
        var filename = string.Format("{0}.json", data);
        //write all text to the file at the path
        File.WriteAllText(path + filename, json);
    }

    public static T Load<T>(string filename) where T : ScriptableObject
    {
        var json = File.ReadAllText(path + filename);
        var scriptableObject = ScriptableObject.CreateInstance<T>();
        JsonUtility.FromJsonOverwrite(json, scriptableObject);
        return scriptableObject;
    }

}