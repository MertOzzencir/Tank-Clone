using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public float DrawRadius;
    Vector3 lastPosition = Vector3.zero;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        foreach (Transform t in transform) {

            Gizmos.DrawSphere(t.position, DrawRadius);

        }
        Gizmos.color = Color.red;
        for (int i = 0; i < transform.childCount - 1; i++) {

            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
            lastPosition = transform.GetChild(i + 1).position;

        }
        Gizmos.DrawLine(lastPosition, transform.GetChild(0).position);


    }


    public Transform nextWaypoint(Transform position)
    {
        if (position == null) {
            return transform.GetChild(0).transform;
        }
        if (position.GetSiblingIndex() < transform.childCount - 1) {
            return transform.GetChild(position.GetSiblingIndex() + 1).transform;
        }
        if (position.GetSiblingIndex() >= transform.childCount - 1) {
            return transform.GetChild(0).transform;
        }
        return null;

    }
}
