using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public static CameraShaker instance;
    Vector3 StartedPosition;
    [SerializeField] public float cameraShakeAmount = 0.2f;
    [SerializeField] private Camera CameraShake;
    float i;
    void Awake()
    {

        instance = this;
        StartedPosition = CameraShake.transform.position;
    }

    void Update()
    {
        CameraShake.transform.position = StartedPosition + Random.insideUnitSphere * cameraShakeAmount;

    }
    public IEnumerator CameraShakeEnabled()
    {
        GetComponent<CameraShaker>().enabled = true;

        yield return new WaitForSeconds(.5f);

        GetComponent<CameraShaker>().enabled = false;

    }


}
