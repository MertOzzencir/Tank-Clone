using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject GunPrefab;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform HitPointGun;
    [SerializeField] private float ShootTime;
    [SerializeField] private float ShootFollowDelayTime;
    [SerializeField] private AudioSource ShootAudio;
    public float sphereRadius = 5f; // Küre yarýçapý
    public LayerMask layerMask; // Çarpýþma için katman seçimi
    public Animator childAnimator;
    float timer;


    void Update()
    {
       
            // Kürenin merkez noktasý
            Vector3 sphereCenter = transform.position;

            // Çarpýþma yapan tüm nesneleri al
            Collider[] colliders = Physics.OverlapSphere(sphereCenter, sphereRadius, layerMask);

            foreach (Collider collider in colliders) {
                timer += Time.deltaTime;
                Vector3 playerDirectionVector = collider.transform.position - GunPrefab.transform.position;
                Quaternion lookDirection = Quaternion.LookRotation(playerDirectionVector);
                GunPrefab.transform.rotation = Quaternion.Slerp(GunPrefab.transform.rotation, lookDirection, ShootFollowDelayTime * Time.deltaTime);
                if (timer > ShootTime) {
                    ShootAudio.Play();
                    GameObject bullet = Instantiate(bulletPrefab, HitPointGun.position, Quaternion.LookRotation(playerDirectionVector));
                    childAnimator.SetTrigger("Attack");
                    bullet.GetComponent<Bullet>().canDestroyShield = false;
                    timer = 0;

                }

            }
       

        
    }
}
