using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

#if UNITY_EDITOR

using UnityEditor;

#endif

public class PathManager
{
    public static readonly string targetPath = "Resources/Data/PathMetaData.json";

    public static readonly HashSet<string> ignoreExtensionSet = new HashSet<string>() { ".meta", ".shader", ".cginc", ".text" };

    public static readonly HashSet<string> ignoreDirectorySet = new HashSet<string>() { "VETASOFT 2DxFX", "ParadoxNotion", };

    private static Dictionary<string, string> database = new Dictionary<string, string>();
    
    [MenuItem("PathData/리소스 폴더 내 파일 경로를 갱신하기")]
    public static void UpdatePathMetadataInMenu()
    {
        UpdatePathMetadata();
    }

    [MenuItem("PathData/Path 데이터 불러오기")]
    public static void LoadPathData()
    {
        Load();
    }

    public static string ToUnixPath(string path)
    {
        return path.Replace('\\', '/');
    }

    public static string ToLeafPath(string filePath)
    {
        string relPath = ToUnixPath(filePath);
        string leafPath = relPath.Trim('/');
        string extension = Path.GetExtension(filePath);
        string fileName = Path.GetFileName(filePath);
        leafPath = leafPath.Substring(0, leafPath.Length - extension.Length);

        return leafPath;
    }

    public static string Lookup(string fileNameWithExtension)
    {
        if (string.IsNullOrEmpty(fileNameWithExtension))
        {
            return null;
        }

        if (database.Count == 0)
        {
            Load();
        }

        if (database.ContainsKey(fileNameWithExtension))
        {
            return database[fileNameWithExtension];
        }
        else
        {
            Debug.LogWarningFormat("PathManager::Lookup(). Failed. fileNameWithExtension:{0}", fileNameWithExtension);
        }
        return null;
    }

    public static void Load()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Data/PathMetadata");

        if (textAsset == null)
        {
            Debug.LogError("Failed to load PathMetadata.");
        }
        else
        {
            try
            {
                database = JsonUtility.FromJson<XSerialization<string, string>>(textAsset.text).ToDictionary();
                if (database.Count > 0)
                {
                    Debug.LogFormat("Load 'PathMetadata'. count: {0}", database.Count);
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }
        }
    }

    public static bool CheckLoaded()
    {
        return database != null && database.Count != 0;
    }

    public static void UpdatePathMetadata()
    {
        database.Clear();

        string[] dirPathes = Directory.GetDirectories(Application.dataPath, "Resources", SearchOption.AllDirectories);

        foreach (string dir in dirPathes)
        {
            string[] filePathes = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories);

            foreach (string filePath in filePathes)
            {
                AddPath(filePath, dir.Length);
            }
        }

        string path = string.Concat(Application.dataPath, '/', targetPath);

        string text = JsonUtility.ToJson(new XSerialization<string, string>(database));

        WriteFile(path, text);
    }

    private static void AddPath(string filePath, int directoryLength)
    {
        if (CheckIgnore(filePath))
        {
            return;
        }

        string relPath = ToUnixPath(filePath.Remove(0, directoryLength));

        string key = Path.GetFileName(filePath);

        if (key.StartsWith("."))
        {
            return;
        }

        if (false == database.ContainsKey(key))
        {
            string leafPath = relPath.Trim('/');

            string extension = Path.GetExtension(filePath);

            string fileName = Path.GetFileName(filePath);

            leafPath = leafPath.Substring(0, leafPath.Length - extension.Length);

            database.Add(fileName, leafPath);

            return;
        }
        else
        {
            Debug.LogWarningFormat("There is data with the same key in the database. FileName: {0}", key);
        }
    }

    private static bool CheckIgnore(string filePath)
    {
        if (ignoreExtensionSet.Contains(Path.GetExtension(filePath)))
        {
            return true;
        }

        foreach (string ignoreDirectory in ignoreDirectorySet)
        {
            if (filePath.Contains(ignoreDirectory))
            {
                return true;
            }
        }

        return false;
    }

    public static bool CheckIgnore(string filePath, HashSet<string> _ignoreExtensionSet)
    {
        if (_ignoreExtensionSet.Contains(Path.GetExtension(filePath)))
        {
            return true;
        }

        foreach (string ignoreDirectory in _ignoreExtensionSet)
        {
            if (filePath.Contains(ignoreDirectory))
            {
                return true;
            }
        }

        return false;
    }

    private static async void WriteFile(string filename, string text)
    {
        StreamWriter file = null;

        try
        {
            file = new StreamWriter(filename, false, Encoding.UTF8);
            await file.WriteAsync(text);
        }
        catch (System.UnauthorizedAccessException)
        {
#if UNITY_EDITOR
            EditorUtility.DisplayDialog("Notice", "You have no write permission in that folder.", "Ok");
#endif
        }
        catch (System.Exception e)
        {
#if UNITY_EDITOR
            EditorUtility.DisplayDialog("Notice", e.Message, "Ok");
#endif
        }
        finally
        {
            if (file != null)
            {
                file.Close();
            }

#if UNITY_EDITOR
            string content = string.Format("Compeleted Write Path MetaData File. count: {0}", database.Count);
            EditorUtility.DisplayDialog("Notice", content, "Ok");
#endif
        }
    }

    public static string FindPrefabPath(string name)
    {
        return Lookup(name + ".prefab");
    }

    public static string FindImagePath(string name)
    {
        return Lookup(name + ".png");
    }

    public static string FindMaterialPath(string name)
    {
        return Lookup(name + ".mat");
    }

    public static string FindAssetPath(string name)
    {
        return Lookup(name + ".asset");
    }

    public static string FindFontPath(string name)
    {
        return Lookup(name + ".ttf");
    }

    public static string FindAudioPath(string name)
    {
        return Lookup(name + ".wav");
    }

    public static string[] FindAllAssetPath()
    {
        List<string> assetPaths = new List<string>();
        foreach (KeyValuePair<string, string> item in database)
        {
            if (item.Key.Contains(".asset"))
            {
                assetPaths.Add(item.Value);
            }
        }
        return assetPaths.ToArray();
    }
}

[System.Serializable]
public class XSerialization<T> : ISerializationCallbackReceiver
{
    [SerializeField]
    private List<T> list;

    public List<T> ToList()
    {
        return list;
    }

    public XSerialization(List<T> list)
    {
        this.list = list;
    }

    public void OnBeforeSerialize()
    {
    }

    public void OnAfterDeserialize()
    {
    }
}

[System.Serializable]
public class XSerialization<TKey, TValue> : ISerializationCallbackReceiver
{
    [SerializeField]
    private List<TKey> keys;

    [SerializeField]
    private List<TValue> values;

    private Dictionary<TKey, TValue> dictionary;

    public Dictionary<TKey, TValue> ToDictionary()
    {
        return dictionary;
    }

    public XSerialization(Dictionary<TKey, TValue> dictionary)
    {
        this.dictionary = dictionary;
    }

    public void OnBeforeSerialize()
    {
        keys = new List<TKey>(dictionary.Keys);

        values = new List<TValue>(dictionary.Values);
    }

    public void OnAfterDeserialize()
    {
        int count = Mathf.Min(keys.Count, values.Count);

        dictionary = new Dictionary<TKey, TValue>(count);

        for (int i = 0; i < count; i++)
        {
            dictionary.Add(keys[i], values[i]);
        }
    }
}