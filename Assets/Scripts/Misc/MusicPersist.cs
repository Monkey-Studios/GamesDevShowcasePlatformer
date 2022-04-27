using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPersist : MonoBehaviour
{
    //This allows the music to retain itself everytime it reloads
    private GameObject[] music;
    //This will perform a check for the object and makes sure it is the only one in the scene
    void Start()
    {
        music = GameObject.FindGameObjectsWithTag("Music");
        Destroy(music[1]);
    }
    //This stops it being destroyed when a new level is loaded
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    //void awake()
    //{
    //    GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
    //    if (objs.Length > 1)
    //        Destroy(this.gameObject);
    //    //if (!objs[0].GetComponent<AudioSource>().isPlaying)
    //    //    objs[0].GetComponent<AudioSource>().Play();
    //    DontDestroyOnLoad(this.gameObject);
    //}
}
