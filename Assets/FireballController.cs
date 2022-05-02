using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    int fireBallDamage = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D FireballCol)
    {
        if(FireballCol.gameObject.tag == "Player")
        {
            FireballCol.transform.GetComponent<PlayerCombat>().takeDmg(fireBallDamage);
        }
        Destroy(this.gameObject);
    }
}
