using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPowerUp : MonoBehaviour
{
    public float AttackShieldTimer;
    GameObject ShiledOffGameObject;
    private void Update()
    {
        transform.Rotate(Vector3.up, 2f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            ShiledOffGameObject= other.gameObject;
            other.gameObject.GetComponent<ShootBullet>().canAttackToShield = true;
            MeshRenderer[] allChildren = GetComponentsInChildren<MeshRenderer>();
            foreach(MeshRenderer child in allChildren) {
                child.enabled = false;
            }
            GetComponent<BoxCollider>().enabled = false;  
            StartCoroutine(EffectTimer());
        }
    }

    IEnumerator EffectTimer()
    {

        yield return new WaitForSeconds(AttackShieldTimer);
        ShiledOffGameObject.GetComponent<ShootBullet>().canAttackToShield = false;
        Destroy(gameObject);
    }


}
