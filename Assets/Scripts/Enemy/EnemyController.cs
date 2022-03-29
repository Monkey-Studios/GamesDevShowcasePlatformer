using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Clearly identifying health numbers to the system
    public int maxHealth = 100;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        //When the game first boots the enemies current health is equal to max
        currentHealth = maxHealth;
    }
    //Function used to reduce health of the enemies, This will be used and refernced in the player combat script 
    public void reduceHealth(int damage)
    {
        //When an enemy is damaged by the player their total health subtracts the player attack total
        currentHealth -= damage;
        //When an enemy is at 0 hp they must die
        if(currentHealth <= 0)
        {
            enemyKilled();
        }
    }
    void enemyKilled()
    {
        Debug.Log("The player has killed an enemy!");
        //Disable the enemy when they are killed
        GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.enabled = false;

    }
}
