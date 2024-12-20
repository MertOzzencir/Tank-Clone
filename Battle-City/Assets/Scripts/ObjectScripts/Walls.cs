    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Walls : MonoBehaviour
    {
        [SerializeField] private int Health;
        [SerializeField] private GameObject piercedWall;
        [SerializeField] bool MainTower;
        
    

    public void GetDamage(int damage)
        {
            Health -=damage;
            CheckHealth();
        }

        void CheckHealth()
        {
            if(Health <= 0) {
            if(MainTower) {

                Instantiate(piercedWall,transform.position, Quaternion.identity);
            }
            else {
                for (int i = transform.childCount - 1; i >= 0; i--) {
                    Transform child = transform.GetChild(i);

                    child.parent = null;
                    Instantiate(piercedWall, child.position, child.rotation);

                    Destroy(child.gameObject);




                }
            }
           


            Destroy(gameObject);
            }  

        }


    }
