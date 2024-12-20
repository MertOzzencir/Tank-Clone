using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShottingWallPowerUp : MonoBehaviour
{
    public GameObject Player;
    private void Start()
    {
        Bullet.OnHit += WallProcudeStoper;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            Player = other.gameObject;
            Player.GetComponent<ShootBullet>().canMakeWall = true;
            MeshRenderer[] allChildren = GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer child in allChildren) {
                child.enabled = false;
            }
            GetComponent<BoxCollider>().enabled = false;
        }
    }
    void WallProcudeStoper()
    {
        if(Player != null) {
            Player.GetComponent<ShootBullet>().canMakeWall = false;
            Destroy(gameObject);
        }
       
    }

    private void OnDestroy()
    {
        Bullet.OnHit -= WallProcudeStoper;
    }
}
