using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIST;
using UnityEngine.UI;
using System.Linq;
using System.IO;
using System;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField] Transform _gridLayout;
    [SerializeField] List<ItemInventoryBase> _items = new List<ItemInventoryBase>();

    List<Transform> _itemSlot = new List<Transform>();
    public List<ItemInventoryBase> items => _items;

    private Dictionary<int, ItemDataSO> gameDataDictionary = new Dictionary<int, ItemDataSO>();
    private string filePath;
    // Start is called before the first frame update
    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "D:\\XuatXuong\\Git\\FPoly_Game\\Assets\\game_data.json");
        Debug.Log(filePath);
        _itemSlot = _gridLayout.GetComponentsInChildren<Transform>().ToList();
        _itemSlot.RemoveAt(0);
        Init();


    }

    void Init ()
    {
        int i = 0;
        
        foreach (ItemInventoryBase item in _items)
        {
            Instantiate(item.gameObject, _itemSlot[i]);
            i++;
            
          
        }
       
        
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Y))
        {
            int i = 0;
            int id = 0;
            foreach (ItemInventoryBase item in _items)
            {
                Instantiate(item.gameObject, _itemSlot[i]);
                i++;
                SaveItemDataSO(item);
                //ItemDataSO data = GetGameDataByID(id);
                //LoadItemDataSO();
            }
            Debug.Log(filePath);
        }
    }
    public void SaveItemDataSO(ItemInventoryBase item)
    {
        try
        {


            string jsonData = JsonUtility.ToJson(item);
            Debug.Log(jsonData);
            //string jsonData = JsonSerializer.Serialize(data);
            File.WriteAllText(filePath, jsonData);
        }
        catch (Exception e)
        {
            Debug.LogError("Save failed: " + e.Message);
        }
    }

    public ItemDataSO LoadItemDataSO()
    {
        try
        {
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                //return JsonSerializer.Deserialize<ItemDataSO>(jsonData);

                return JsonUtility.FromJson<ItemDataSO>(jsonData);
            }
            else
            {
                Debug.LogWarning("No saved data found.");
                return null;
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Load failed: " + e.Message);
            return null;
        }
    }

    private ItemDataSO GetGameDataByID(int id)
    {
        if (gameDataDictionary.ContainsKey(id))
        {
            return gameDataDictionary[id];
        }
        else
        {
            return null;
        }
    }
}
