using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    public Animator transition;
    public GameObject victoryCanvas,coinCanvas;
   public void Level(string scenename)
    {
        victoryCanvas.SetActive(false);
        coinCanvas.SetActive(false);
        StartCoroutine(LoadLevel(scenename));
        
    }

    IEnumerator LoadLevel(string level)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(level);
    }

}
