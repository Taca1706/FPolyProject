using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    public GameObject _iventoryPanel;
    bool isPause,isInventory,isStore,isSkilClass;
    public GameObject _storePanel;
    public GameObject _skillPanel;
    public GameObject _inGameUIPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IventoryPanel();
        //StorePanel();
        //SkillPanel();
        ReturnGame();
    }
    public void IventoryPanel()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {

            _iventoryPanel.SetActive(true);
            _inGameUIPanel.SetActive(false);
            Time.timeScale = 0;
            isPause = true;
            isInventory = true;
            isStore = false;
            isSkilClass = false;
        }

    }

    public void StorePanel()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _iventoryPanel.SetActive(false);
            _storePanel.SetActive(true);
            isInventory = false;
            isStore = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {

            _iventoryPanel.SetActive(true);
            _storePanel.SetActive(false);
            isInventory = true;
            isStore = false;
        }


    }
    public void SkillPanel()
    {
        if (isInventory == true && isSkilClass == false && Input.GetKeyDown(KeyCode.E))
        {
            _iventoryPanel.SetActive(false);
            _skillPanel.SetActive(true);
            isInventory = false;
            isSkilClass = true;
        }
        if (isSkilClass == true && Input.GetKeyDown(KeyCode.Q))
        {

            _iventoryPanel.SetActive(true);
            _skillPanel.SetActive(false);
            isInventory = true;
            isSkilClass = false;
        }
    }
    public void ReturnGame()
    {
        if (isInventory == true && Input.GetKeyDown(KeyCode.Escape))
        {
            
            _iventoryPanel.SetActive(false);
            _inGameUIPanel.SetActive(true);
            Time.timeScale = 1;
            isPause = false;
        }
    }

}
