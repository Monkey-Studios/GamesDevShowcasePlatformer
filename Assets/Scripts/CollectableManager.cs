using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D scriptCol)
    {
        Debug.Log("I have collided");
        ScoreManager.instance.AddScore();
        Destroy(this.gameObject);
    }
}
