using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    //Setting up some variables which will be used for the functionality of detecting and attacking the player.
    public float moveSpeed = 2;
    public float Range;
    public float minDistFromPlayer = 0.5f;
    public float fireRate;
    public float shootingForce;
    float timeToNextShot = 0;
    //These are used for when the player gets behind the boss
    public float waitTime = 5;
    private float currentWaitTime = 0;
    public bool playerBehind = false;
    //These are used for the boss to shoot fireballs
    public GameObject Fireball;
    public Transform shootPoint;
    public Transform Target;
    //These are used for the movement and flipping of the boss when changing directions
    Rigidbody2D bossRigidBody;
    bool playerDetected = false;
    //Used to check the bosses facing direction
    Vector2 bossDirection;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 0;
        bossRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is largly used for detecting and attacking the player and where the boss should be facing in relation to the player
    void Update()
    {
        //The enemy will move right at the set move speed
        if (FacingDirection())
        {
            bossRigidBody.velocity = new Vector2(moveSpeed, bossRigidBody.velocity.y);
        }
        //If not then they will move left at the set move speed
        else
        {
            bossRigidBody.velocity = new Vector2(-moveSpeed, bossRigidBody.velocity.y);
        }

        //This obtains the direction of the target
        Vector2 targetPos = Target.position;
        //This is then used to work out the distance between the boss and the player target
        bossDirection = targetPos - (Vector2)transform.position;
        //This raycast will be used to detect the player. If it does so then shoot at the player
        RaycastHit2D rayDectect = Physics2D.Raycast(transform.position, bossDirection, Range);
        //This IF statement will perform checks to see if it has detected something or not and respond according to its logic
        if (rayDectect)
        {
            if (rayDectect.collider.gameObject.tag == "Player")
            {
                playerDirectionalContext();
                if(Vector2.Distance(targetPos, (Vector2)transform.position) <= minDistFromPlayer)
                {
                    moveSpeed = 0;
                }
                //Tells the boss the player is within range
                if (playerDetected == false)
                {
                    playerDetected = true;
                    Debug.Log("Player detected");
                }
            }
        }
        else
        {
            //Tells the boss the player is out of range
            if (playerDetected == true)
            {
                playerDetected = false;
                moveSpeed = 0;
                Debug.Log("No player detected");
            }
        }
        /*If the player is detected then the script will check if the enemy can fire again 
         and perform the fire script*/
        if (playerDetected)
        {
            if (Time.time > timeToNextShot && !playerBehind)
            {
                /* if time.time is greater than the next time the boss can shoot, 
                Then it will perform the following calculation to determine its next opportunity to fire */
                timeToNextShot = Time.time + 1 / fireRate;
                shootFireball();
            }
            //If the player is behind the boss it must wait till its "wait time" is up before looking to face them
            if(playerBehind)
            {
                currentWaitTime += Time.deltaTime;
                if(currentWaitTime > waitTime)
                {
                    currentWaitTime = 0;
                    transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                    //flip boss
                    Debug.Log("Boss flip");
                }
            }
            //Resets wait time to 0 when the player isnt behind
            else
            {
                currentWaitTime = 0;
            }
        }
    }
    //This funcion is called upon within the boss detection and used to fire at the player
    void shootFireball()
    {
        GameObject FireballInstance = Instantiate(Fireball, shootPoint.position, Quaternion.identity);
        FireballInstance.GetComponent<Rigidbody2D>().AddForce(bossDirection * shootingForce);
    }
    //This checks if the bosses X scale is facing right
    private bool FacingDirection()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
    //This is used to check if the player is infront of the boss or not
    void playerDirectionalContext()
    {
        if(FacingDirection())
        {
            //If the boss is facing toward the player then continue walking toward them
            if (bossDirection.x > 0)
            {
                moveSpeed = 2;
                playerBehind = false;
            }
            //If the boss is facing away then stop and wait
            else
            {
                moveSpeed = 0;
                playerBehind = true;
            }
        }
        else
        {
            //If the boss is facing toward the player then continue walking toward them
            if (bossDirection.x < 0)
            {
                moveSpeed = 2;
                playerBehind = false;
            }
            //If the boss is facing away then stop and wait
            else
            {
                moveSpeed = 0;
                playerBehind = true;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
