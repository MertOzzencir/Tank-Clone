using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{

    [SerializeField] private Transform RotateObject;
    [SerializeField] private KeyCode RotateRightKey;
    [SerializeField] private KeyCode RotateLeftKey;

    [SerializeField] private float RotateAmount;
    

    void Update()
    {
        if(Input.GetKey(RotateRightKey)) {
            RotateObject.transform.Rotate(0, RotateAmount, 0);
        }
        if (Input.GetKey(RotateLeftKey)) {
            RotateObject.transform.Rotate(0, -RotateAmount, 0);
        }
    }
}
