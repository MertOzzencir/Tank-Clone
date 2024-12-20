using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Transform RotateBodyToDirection;
    [SerializeField] private float rotateSpeedOfBody;
    [SerializeField] float acceleration;
    [SerializeField] GameObject Head;

    [Header("Custom Movement Keys")]
    [SerializeField] private KeyCode forward = KeyCode.W;
    [SerializeField] private KeyCode backward = KeyCode.S;
    Rigidbody rb;
    float mass;
    float forcePower;
    int inputVector;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mass = rb.mass;
        forcePower = mass * acceleration;
    }


    void Update()
    {
        RotateBody();
        inputVector = InputVector();

    }
    private void FixedUpdate()
    {
        if (inputVector != 0) {
            Vector3 forwardDirection = Head.transform.forward; // Bir kez hesapla
            Vector3 forceDirection = forwardDirection * inputVector * acceleration;
            rb.AddForce(forceDirection, ForceMode.Impulse);
        }
        else {
            Vector3 currentVelocity = rb.velocity;

            // Sadece x ve z eksenlerini Lerp ile yavaþlat, y ekseni ayný kalýr
            Vector3 targetVelocity = new Vector3(0, currentVelocity.y, 0);
            Vector3 smoothedVelocity = Vector3.Lerp(currentVelocity, targetVelocity, 0.1f);

            rb.velocity = new Vector3(smoothedVelocity.x, currentVelocity.y, smoothedVelocity.z);
        }
    }


    void RotateBody()
    {

        if (InputVector() !=0) {

            Quaternion targetRotation = Quaternion.LookRotation(Head.transform.forward, Vector3.up);
            

            RotateBodyToDirection.rotation = Quaternion.Slerp(RotateBodyToDirection.rotation, targetRotation, rotateSpeedOfBody);
            
        }
        
    }

    private int InputVector()
    {

        if(Input.GetKey(forward)) {
            return 1;
        }
        if(Input.GetKey(backward)) {
            return -1;
        }
        else {
            return 0;
        }
        
        
    }
}
