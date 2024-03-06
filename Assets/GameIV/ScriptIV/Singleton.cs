// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace VIST
{
    
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T _instance =null;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    Debug.LogWarning("==> Singleton does not exits <==");
                    _instance = FindObjectOfType<T>();
                }
                return _instance;
            }
        }      
        protected virtual void Awake()
        {
            if (_instance != null && _instance.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
            {
                Destroy(this.gameObject);
            }
            else _instance = this.GetComponent<T>();


        }

        
        
    }
}
