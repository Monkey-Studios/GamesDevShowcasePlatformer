using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //The attack point is an empty object on the end of a weapon which is used to determine where on the player the attack comes from
    public Transform attackPoint;
    //Setting attack range and attack damage points
    public float attackRange = 0.35f;
    public int attackDamage = 40;
    //In order to balance the players attack the system needs to have a dps rate set
    public float dmgPerSecond = 2f;
    //Here the system is setting a time window between attacks
    float attackWindow = 0f;
    /*For enemy detection i'll be using layers specifically for enemies.
     When the player attacks it looks to see if it its on that layer and determines if its an enemy*/
    public LayerMask enemyLayers;

    // Update is used to perform checks for the player attacking
    void Update()
    {
        if(Time.time >= attackWindow)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerAttack();
                attackWindow = Time.time + 1f / dmgPerSecond;
                Debug.Log("Attack");
            }
        }

    }
    /*This will check the range of any nearby enemies
     If they are within range then the attack will apply damage to the enemy*/
    void PlayerAttack()
    {
        //This creates a cirle around the attack point and checks the objects that have been hit
        //The 2d collider array is used to store all the enemies that have been hit within the radius of the attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers); 
        //In order to apply damage the system will loop through and find each enemy that has been hit
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("Player has hit" + enemy.name);
            enemy.GetComponent<EnemyController>().reduceHealth(attackDamage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
