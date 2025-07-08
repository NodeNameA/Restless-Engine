using System;
using System.IO;
using UnityEngine;

namespace RestlessLib.SaveUtility
{
    public static class SaveUtility
    {
        public static void Save(ScriptableObject data)
        {
            try
            {
                string json = JsonUtility.ToJson(data, true);
#if UNITY_EDITOR
                string path = Path.Combine("Assets/Saves/", data.name);
#else
                string path = Path.Combine(Application.persistentDataPath, data.name);
#endif
                File.WriteAllText(path, json);
                Debug.Log("Data saved successfully.");
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to save data: {e.Message}");
            }
        }

        public static bool Load(ScriptableObject data)
        {
            try
            {

#if UNITY_EDITOR
                string path = Path.Combine("Assets/Saves/", data.name);
#else
                string path = Path.Combine(Application.persistentDataPath, data.name);
#endif

                if (File.Exists(path))
                {
                    string json = File.ReadAllText(path);
                    JsonUtility.FromJsonOverwrite(json, data);
                    Debug.Log("Data loaded successfully.");
                    return true;
                }
                else
                {
                    Debug.LogWarning("Save file not found.");
                    return false;
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to load data: {e.Message}");
                return false;
            }
        }

        public static void Save(object data, string filename)
        {
            try
            {
                string json = JsonUtility.ToJson(data, true);
#if UNITY_EDITOR
                string path = Path.Combine("Assets/Saves/", filename);
#else
                string path = Path.Combine(Application.persistentDataPath, filename);
#endif
                string directory = Path.GetDirectoryName(path);
                Debug.Log($"Saving to {path} | {directory}");
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                File.WriteAllText(path, json);
                Debug.Log("Data saved successfully.");
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to save data: {e.Message}");
            }
        }

        public static bool Load(object obj, string filename)
        {
            try
            {
#if UNITY_EDITOR
                string path = Path.Combine("Assets/Saves/", filename);
#else
                string path = Path.Combine(Application.persistentDataPath, filename);
#endif

                if (File.Exists(path))
                {
                    string json = File.ReadAllText(path);
                    JsonUtility.FromJsonOverwrite(json, obj);
                    Debug.Log("Data loaded successfully.");
                    return true;
                }
                else
                {
                    Debug.LogWarning("Save file not found.");
                    return false;
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to load data: {e.Message}");
                return false;
            }
        }

    }

}
