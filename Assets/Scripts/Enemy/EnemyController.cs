using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Clearly identifying health numbers to the system
    public int maxHealth = 100;
    int currentHealth;
    //Set a range for the enemies attacks along with a total damage output
    float rayRange = 1f;
    int enemyAttackDmg = 10;
    //So that the player isnt killed instantly I have set an attack rate for the enemy
    public float dmgPerSecond = 2f;
    //This function will be used to calcuate how often th enemy can attack
    float attackWindow = 0f;
    //Set enemy health at the start of the game
    void Start()
    {
        //When the game first boots the enemies current health is equal to max
        currentHealth = maxHealth;
    }
    private void Update()
    {
        if (Time.time >= attackWindow)
        {
            enemyAttack();
        }
    }
    private bool lookingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
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
    void enemyAttack()
    {
        //This newly created raycast is used to correctly position the raycast on the enemies body
        Vector2 midPoint = transform.position;
        midPoint.y += 0.8f;
        Vector2 lookingDirection = Vector2.right;
        //This checks if the enemy is looking left and if that is the case it tells the enemy to do so when needed
        if(!lookingRight())
        {
            lookingDirection = -Vector2.right;
        }
        //Sends out a ray cast which will check for enemies in range
        Debug.DrawRay(midPoint, lookingDirection, Color.white);
        RaycastHit2D[] hitPlayer = Physics2D.RaycastAll(midPoint, lookingDirection, rayRange);
        //This for loop will go through array checking all hit points seeing if the player has been hit. If this is the case then the attack function is set.
        for (int i = 0; i < hitPlayer.Length; i++)
        {
            if (hitPlayer[i].collider != null && hitPlayer[i].collider.tag == ("Player"))
            {
                Debug.Log("I have hit you " + hitPlayer[i].collider.tag);
                hitPlayer[i].transform.GetComponent<PlayerCombat>().takeDmg(enemyAttackDmg);
                attackWindow = Time.time + 1f / dmgPerSecond;
            }
        }
    }
}
