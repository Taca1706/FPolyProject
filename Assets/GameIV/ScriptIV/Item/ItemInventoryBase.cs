using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemInventoryBase : MonoBehaviour
{
    [SerializeField]
    protected ItemDataSO _info;
    [SerializeField]
    protected int _quantity;
    [SerializeField]
    protected string _note;
    [SerializeField]
    protected int _maxCapacity;
    
}


