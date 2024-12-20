using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashForce = 20f;        // Dash kuvveti
    public float dashDuration = 0.2f;   // Dash süresi
    public float dashCooldown = 1f;     // Dash tekrar kullanýmý için bekleme süresi
    public KeyCode DashKey;
    public GameObject DashIcon;

    private Rigidbody rb;
    private bool isDashing = false;
    private float dashEndTime;
    private float lastDashTime;
    public GameObject dashDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if ( Time.time >= lastDashTime + dashCooldown && !isDashing) {
            DashIcon.SetActive(true);

            if (Input.GetKeyDown(DashKey)) {
                StartDash();

            }
        }

        if (isDashing && Time.time >= dashEndTime) {
            EndDash();
        }
    }

    void StartDash()
    {
        DashIcon.SetActive(false);
        isDashing = true;
        lastDashTime = Time.time;
        dashEndTime = Time.time + dashDuration;

      
        rb.AddForce(dashDirection.transform.forward * dashForce, ForceMode.Impulse);
    }

    void EndDash()
    {
        isDashing = false;
    }
}
