using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class Spawner : MonoBehaviour
{
   
    [SerializeField] private Vector3 SpawnPoint;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
       
        if(transform.position.y < -25) {

            rb.velocity = Vector3.zero;
            SpawnAgain();
        }
        
    }

    private void SpawnAgain()
    {
        transform.position = SpawnPoint;
    }
}
