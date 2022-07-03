using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Pooling;

public class BlockPoolManager : MonoBehaviour
{
    [SerializeField] private GameObjectPoolerManager poolerManager;
    void Start()
    {
        poolerManager.Prepool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
