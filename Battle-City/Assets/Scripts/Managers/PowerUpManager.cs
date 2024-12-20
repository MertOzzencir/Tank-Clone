using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [Header("Piercing Bullet Power Up")]
    [SerializeField] private GameObject[] PowerUpPrefabs;
    [SerializeField] private Transform PiercingBulletTransformToInstantiate;
    [SerializeField] private int PiercingBulletBulletInstantiateTimer;

    float PiercingBullettimer;
    GameObject threshHolder;
    void Update()
    {

        PiercingBullettimer += Time.deltaTime;


        if( threshHolder == null) {
            if(PiercingBullettimer > PiercingBulletBulletInstantiateTimer) {
                int powerUpPickChance = Random.Range(0, 1000);
                if(powerUpPickChance <800) {
                    threshHolder = Instantiate(PowerUpPrefabs[0], PiercingBulletTransformToInstantiate.position, Quaternion.identity);

                }
                if(powerUpPickChance >= 800) {
                    threshHolder = Instantiate(PowerUpPrefabs[1], PiercingBulletTransformToInstantiate.position, Quaternion.identity);

                }
                PiercingBullettimer = 0;

            }


        }
    }
}
