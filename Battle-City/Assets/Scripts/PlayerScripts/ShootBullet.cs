using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    [Header("General Setup")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletTransform;
    [SerializeField] private KeyCode bulletShootKeyCode;
    [SerializeField] GameObject PiercedPowerUpEffect;



    [Header("Shoot Settings")]
    [SerializeField] float reloadTime;
    [SerializeField] float pushBackPower;
    [SerializeField] float pushUpPower;

    PlayerMovement PlayerMovementScript;

    [SerializeField] private GameObject ShootEffect;
    public bool canAttackToShield;
    public bool canMakeWall;
    public AudioSource ShootVoice;
    [SerializeField] private GameObject ShootIcon;
    float timer = 4f;

    Rigidbody rb;
    private void Start()
    {
        rb=GetComponent<Rigidbody>();
        PlayerMovementScript = GetComponent<PlayerMovement>();
        

    }
    void Update()
    {
        timer += Time.deltaTime;
        if( timer>reloadTime) {
            ShootIcon.SetActive(true);
            if (Input.GetKeyDown(bulletShootKeyCode)) {
                ShootEffect.SetActive(true);
                StartCoroutine(Shoot());
                ShootVoice.Play();
                timer = 0;
            }
            
        }
        if (canAttackToShield) {
            PiercedPowerUpEffect.SetActive(true);
        }
        else {
            PiercedPowerUpEffect.SetActive(false);
        }
        
    }

    IEnumerator Shoot()
    {
        ShootIcon.SetActive(false);

        PlayerMovementScript.enabled = false;
        GameObject bullet = Instantiate(bulletPrefab, bulletTransform.position, bulletTransform.rotation);
        Bullet bullets = bullet.GetComponent<Bullet>();
        bullets.Owner = gameObject;
        bullets.canDestroyShield = canAttackToShield;
        bullets.canMakeWall = canMakeWall;
        rb.AddForce(-bulletTransform.transform.forward * pushBackPower, ForceMode.Impulse);
        
        rb.AddForce(Vector3.up * pushUpPower, ForceMode.Impulse);
        yield return new WaitForSeconds(0.25f);
        PlayerMovementScript.enabled = true;
    }
}
