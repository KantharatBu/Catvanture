using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootCheck : MonoBehaviour
{
    public Animator anim;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyHeadCheck>())
        {
            anim.SetBool("isDead", true);
            Destroy(collision.gameObject);
        }
    }

    void Dead()
    {
        Destroy(transform.parent.gameObject);
    }
}
