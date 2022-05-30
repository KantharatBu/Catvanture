using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    //int coinScore;
    //public Text coinText; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            //coinScore = coinScore + 1;
            //coinText.text = coinScore.ToString();
        }
    }
}
