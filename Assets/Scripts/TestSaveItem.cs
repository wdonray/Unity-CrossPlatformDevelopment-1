using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class TestSaveItem : MonoBehaviour
{
    public BackPackBehaviour backPackBehaviour;
    public List<Item> bp;
    public KevlarVest kv;
    private string path;
    private int numsaves = 0;
    public int loadnum;
    public List<KevlarVest> saveStates = new List<KevlarVest>();
    private void Awake()
    {
        path = Application.dataPath + "/" + "StreamingAssets";
    }
    // Use this for initialization
    private void Start()
    {
        kv = Instantiate(kv);
        kv.Initialize(gameObject);
    }
    
    public void Save()
    {
        string jsonstring = JsonUtility.ToJson(kv, true);
        var filename = "/" + kv.Name + "{" + numsaves + "}" + ".json";
        var file = new System.IO.StreamWriter(path + filename);
        file.WriteLine(jsonstring);
        file.Close();
        numsaves += 1;
        var newkv = ScriptableObject.CreateInstance<KevlarVest>();
        var json = File.ReadAllText(path + filename);
        
        JsonUtility.FromJsonOverwrite(json, newkv);
        saveStates.Add(newkv);
    }

    public void SaveBackPack()
    {
         bp = backPackBehaviour.Items;
        string jsonstring = JsonUtility.ToJson(bp, true);
        var filename = "/" + bp.GetType() + "-" + numsaves + ".json";
        var file = new StreamWriter(path + filename);
        file.WriteLine(jsonstring);
        file.Close();
        numsaves += 1;
        var newkv = ScriptableObject.CreateInstance<BackPack>();
        var json = File.ReadAllText(path + filename);
    }

    public void LoadBackPack()
    {
        var id = loadnum.ToString();
        var filename = "/" + bp + "-" + id + ".json";
        var json = File.ReadAllText(path + filename);
        JsonUtility.FromJsonOverwrite(json, bp);
    }
    

    public void Load()
    {
        var id = loadnum.ToString();
        
        var filename = "/" + kv.Name + "{" + id + "}" + ".json";
        var json = File.ReadAllText(path + filename);
        JsonUtility.FromJsonOverwrite(json, kv);
        
    }
}

