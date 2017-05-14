using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DataController : MonoBehaviour
{
    public BackPack config;
    private static Dictionary<int, string> _saved = new Dictionary<int, string>();
    private static int _index;
    private void Start()
    {
        SaveBackPack(config);
    }

    public void OnSaveBackPack(BackPack bp)
    {
        SaveBackPack(bp);
    }
    public static void SaveBackPack(BackPack backpack)
    {
        var savestring = JsonUtility.ToJson(backpack);
        _saved.Add(_index, savestring);
        Debug.LogFormat("{0} saved at {1}", backpack, _index);
        _index++;
    }

    public static BackPack LoadBackPack(int index)
    {
        string bp = _saved[index];
        BackPack newbp = JsonUtility.FromJson<BackPack>(bp);
        return newbp;
    }
}
