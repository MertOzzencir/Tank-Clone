using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int PlayerOfHealth;
   
    public void GetDamage(int damage)
    {
        PlayerOfHealth -= damage;
        CheckHealth();

    }
    public void CheckHealth()
    {
        if(PlayerOfHealth <= 0)
            Destroy(gameObject);

    }
}
