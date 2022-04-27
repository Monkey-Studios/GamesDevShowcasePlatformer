using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D scriptCol)
    {
        //When the player collides with this object it is destoryed and adds 1 to the player score.
        ScoreManager.instance.AddScore();
        Destroy(this.gameObject);
    }
}
