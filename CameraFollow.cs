using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed;
    float yPos;

    private Transform player;
    void Start()
    {
        player = GameObject.Find("Cat").transform;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 targetPos = player.position;
        Vector2 smoothPos = Vector2.Lerp(transform.position,targetPos,followSpeed*Time.deltaTime);

        transform.position = new Vector3(smoothPos.x, smoothPos.y + yPos, -15f);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            yPos = 0f;
        }
        else
        {
            yPos = 0.2f;
        }
    }
}
