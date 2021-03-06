using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;
using UnityEngine.Networking;

public class Hotfix : MonoBehaviour
{
    private LuaEnv luaEnv;
    private Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>();
    private void Awake()
    {
        luaEnv = new LuaEnv();
        luaEnv.AddLoader(MyLoader);
        luaEnv.DoString("require'Test'");
    }

    private byte[] MyLoader(ref string filePath)
    {
        string absPath = @"D:\Unity Project\learn_xlua\Assets\LuaScripts\" + filePath + ".lua.txt";
        return System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(absPath));
    }


    private void OnDisable()
    {
        luaEnv.DoString("require'Dispose'");
    }
    private void OnDestroy()
    {
        
        luaEnv.Dispose();
    }

    [LuaCallCSharp]
    public void LoadResource(string resName, string filePath)
    {
        StartCoroutine(Load(resName,filePath));
    }
    IEnumerator Load(string resName, string filePath)
    {
        
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(@"http://localhost/AssetBundles/" + filePath);
        
        yield return request.SendWebRequest();
        AssetBundle ab = (request.downloadHandler as DownloadHandlerAssetBundle).assetBundle;
        GameObject go = ab.LoadAsset<GameObject>(resName);
        
        prefabs.Add(resName, go);
        Debug.Log(prefabs[resName]);
    }

    [LuaCallCSharp]
    public GameObject GetPrefabs(string resName)
    {
        return prefabs[resName];
        
    }
}
