using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RamCleanManager : MonoBehaviour
{

    [SerializeField] private float CacheCleanTimer;
    [SerializeField] private bool FlagBoolForCache;

    float timer;

    void Update()
    {

        timer += Time.deltaTime;
        if(timer > CacheCleanTimer && FlagBoolForCache) {
            Resources.UnloadUnusedAssets();
            timer = 0;
            Debug.Log("Cache has been Cleaned");
        }
    }
}
