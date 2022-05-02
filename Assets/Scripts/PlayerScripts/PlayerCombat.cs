using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{
    //The attack point is an empty object on the end of a weapon which is used to determine where on the player the attack comes from
    public Transform attackPoint;
    //Setting attack range and attack damage points
    public float attackRange = 0.35f;
    public int attackDamage = 40;
    //Setting player health
    public int playerHealth = 100;
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
            try
            {
                enemy.GetComponent<EnemyController>().reduceHealth(attackDamage);
            }
            catch
            {
                enemy.GetComponent<BossController>().reduceBossHealth(attackDamage);
            }  
        }
    }
    //This function is used and called upon within the enemy attack script to hurt the player
    public void takeDmg(int enemyDamage)
    {
        //When the player is attacked by an enemy their total health is reduced by the total damage of the attack
        playerHealth -= enemyDamage;
        //When the player runs out of health the playerKilled function is activated
        if(playerHealth <= 0 )
        {
            playerKilled();
            SceneManager.LoadScene("GameOverLevelOne");
        }
    }
    //This function is called upon when the player has no health remaining
    void playerKilled()
    {
        Debug.Log("Player is dead");
        //When the player is killed they are disabled and taken to the defeat screen
        GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.enabled = false;
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
