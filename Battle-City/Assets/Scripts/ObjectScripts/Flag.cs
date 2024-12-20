using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] private int Health;
    [SerializeField] private GameObject DestroyPlayer;
    [SerializeField] private Vector3 TowerPosition;
    [SerializeField] private GameObject TowerPrefab;






    public void Damaged(int damageAmount, bool canTakeDamage,GameObject owner,bool canMakeWallAgain)
    {
        if(canTakeDamage && owner != DestroyPlayer) {
            Health -= damageAmount;
            checkHealth();
            Debug.Log("Flag get Damaged");
        }
        if (canMakeWallAgain && owner == DestroyPlayer) {
            Debug.Log("HAS BEEN SLAYED");
            Instantiate(TowerPrefab,TowerPosition, Quaternion.identity);
        }
       
    }

    void checkHealth()
    {
        if(Health <= 0) {
            Debug.Log("Player Destroyed");
            
            Destroy(DestroyPlayer);
            Destroy(gameObject);
        }

    }
}
