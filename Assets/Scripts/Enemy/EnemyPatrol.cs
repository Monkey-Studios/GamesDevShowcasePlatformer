using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] 
    //Enemy movement field
    float moveSpeed = 1f;
    //Getting reference for the rigid body
    Rigidbody2D enemyRigidBody;
    //This checks if the enemies X scale is facing right
    private bool lookingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
    void Start()
    {
        //Reference to the rigid body
        enemyRigidBody = GetComponent<Rigidbody2D>();
    }

    // Updates and checks where the enemy is looking
    void Update()
    {
        //The enemy will move right at the set move speed
        if (lookingRight())
        {
            enemyRigidBody.velocity = new Vector2(moveSpeed, enemyRigidBody.velocity.y);
        }
        //If not then they will move left at the set move speed
        else
        {
            enemyRigidBody.velocity = new Vector2(-moveSpeed, enemyRigidBody.velocity.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D enemyCollide)
    {
        /*Used to turn the enemy the opposite way when they detect a collision. 
         * By using local scale this system will automatically detect any changes in size and compensate accordingly, it also means im not hard coding scaling factors of the enemy in code */
        transform.localScale = new Vector2(-(Mathf.Sign(enemyRigidBody.velocity.x)), transform.localScale.y);
    }
}
