using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static event Action OnHit;
    [SerializeField] private float bulletShootPower;
    [SerializeField] private int attackDamage;
    [SerializeField] private float pushBackPower;
    [SerializeField] private GameObject WallPrefab;
    [SerializeField] private GameObject BombEffect;

    public GameObject Owner;
    public bool canDestroyShield;
    public bool canMakeWall;
    Rigidbody rb;
    bool canShoot = true;
    bool canEffect = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (canShoot) {
            rb.AddForce(transform.forward * bulletShootPower, ForceMode.Impulse);
            Destroy(gameObject, 2f);
            canShoot = false;
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (canEffect && collision.contacts.Length > 0) {

            Vector3 contactpoint = collision.contacts[0].point;
            GameObject effect = Instantiate(BombEffect, contactpoint, Quaternion.identity);
            effect.transform.parent = null;
            canEffect = false;
        }
        if (collision.gameObject.GetComponent<Flag>() != null) {
            collision.gameObject.GetComponent<Flag>().Damaged(attackDamage, canDestroyShield, Owner, canMakeWall);
            OnHit?.Invoke();
           
            Destroy(gameObject);
        }
        else if (canMakeWall) {
            canMakeWall = false;
            Vector3 spawnPoint=Vector3.zero;
            Quaternion rotation = Quaternion.identity;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward,out hit, 3f)) {
                spawnPoint = hit.point;
                Vector3 surfaceNormal = hit.normal;
                rotation = Quaternion.LookRotation(hit.normal);


            }

            Instantiate(WallPrefab, spawnPoint, rotation);
            OnHit?.Invoke();
            

            Destroy(gameObject);

        }
        
        else if (collision.gameObject.GetComponent<PlayerMovement>() != null) {
            collision.gameObject.GetComponent<PlayerHealth>().GetDamage(attackDamage);
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * pushBackPower, ForceMode.Impulse);
            

            Destroy(gameObject);
        }
       
        else if (collision.gameObject.GetComponent<Walls>() != null) {
           
            if (canDestroyShield) {
                collision.gameObject.GetComponent<Walls>().GetDamage(attackDamage);
                
                Destroy(gameObject);
            }
            
        }

      



    }


}
