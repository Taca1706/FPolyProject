using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIST;
using System.Linq;

public class DataManager : Singleton<DataManager>
{
    [Header("--------------Item-------------")]
    [SerializeField] List<ItemDataSO> _genaralDataItems = new List<ItemDataSO>();
    public List<ItemDataSO> genaralDataItems => _genaralDataItems;

    
    


    
    // Start is called before the first frame update
    void Start()
    {


        Init();
    }
    
    public void Init ()
    {
        _genaralDataItems = Resources.LoadAll<ItemDataSO>("Item").ToList();
       
    }
    
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Y))
        //{
            
        //}
    }
    
    private void OnDrawGizmosSelected()
    {
        
    }
}
