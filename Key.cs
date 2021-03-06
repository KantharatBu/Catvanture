using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject door;
    public ParticleSystem expotion;
    public AudioSource doorSound;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            doorSound.Play();
            expotion.Play();
            Destroy(gameObject);
            Destroy(door);
            
        }
    }
}
