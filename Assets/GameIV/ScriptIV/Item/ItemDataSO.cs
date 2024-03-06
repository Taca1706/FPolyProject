using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Data;
using System;

[CreateAssetMenu(fileName = "itemData",menuName =" Item")]
public class ItemDataSO : ScriptableObject
{
    public int _ID;
    public string _name;
    public Sprite _image;
}

//public class SaveLoadManager : MonoBehaviour
//{
//    private string filePath;

//    void Start()
//    {
//        filePath = Path.Combine(Application.persistentDataPath, "game_data.json");
//        Debug.Log(filePath);
//    }

//    public void SaveItemDataSO(ItemDataSO data)
//    {
//        try
//        {
//            string jsonData = JsonUtility.ToJson(data);

//            //string jsonData = JsonSerializer.Serialize(data);
//            File.WriteAllText(filePath, jsonData);
//        }
//        catch (Exception e)
//        {
//            Debug.LogError("Save failed: " + e.Message);
//        }
//    }

//    public ItemDataSO LoadItemDataSO()
//    {
//        try
//        {
//            if (File.Exists(filePath))
//            {
//                string jsonData = File.ReadAllText(filePath);
//                //return JsonSerializer.Deserialize<ItemDataSO>(jsonData);

//                return JsonUtility.FromJson<ItemDataSO>(jsonData);
//            }
//            else
//            {
//                Debug.LogWarning("No saved data found.");
//                return null;
//            }
//        }
//        catch (Exception e)
//        {
//            Debug.LogError("Load failed: " + e.Message);
//            return null;
//        }
//    }
//}