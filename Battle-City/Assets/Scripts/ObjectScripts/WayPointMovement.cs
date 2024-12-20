using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointMovement : MonoBehaviour
{
    public WayPoint Waypoint;
    public Transform currentTransform;
    public float Speed;


    void Start()
    {
        Waypoint = FindAnyObjectByType<WayPoint>();    
        currentTransform = Waypoint.nextWaypoint(currentTransform);
        transform.position = currentTransform.position;
        currentTransform = Waypoint.nextWaypoint(currentTransform);

    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTransform.position, Speed * Time.deltaTime);
        Vector3 lookRotation = new Vector3(
    currentTransform.position.x - transform.position.x,
    0, 
    currentTransform.position.z - transform.position.z
);
        Quaternion quaternion = Quaternion.LookRotation(lookRotation);
        transform.rotation = quaternion;
        transform.position = new Vector3(transform.position.x, 1.15f, transform.position.z);
        if (Vector3.Distance(transform.position, currentTransform.position) < 0.1f)
            currentTransform = Waypoint.nextWaypoint(currentTransform);
    }
}
