using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayMenu : MonoBehaviour
{
    public GameObject menu;

    private void Update()
    {
        StartCoroutine(Delay(menu));
    }

    IEnumerator Delay(GameObject menu)
    {
        yield return new WaitForSeconds(1);

        menu.SetActive(true);
    }
}
