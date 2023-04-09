using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyMove : MonoBehaviour
{
    GameObject player;

    public float period = 5f;
    public float magnitude = 1f;

    public float followTime = .25f;

    public float offsetX = 2f;
    public float offsetY = 1f;

    float targetX;
    float targetY;

    float tempX;
    float tempY;

    float fireflySpeedX;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        targetX = player.transform.position.x + offsetX;
        targetY = player.transform.position.y + offsetY;
        
        tempX = Mathf.SmoothDamp(transform.position.x, targetX, ref fireflySpeedX, followTime);
        tempY = Mathf.Sin(Time.time / period) * magnitude;

        transform.position = new Vector3(tempX, tempY, 0f);
    }
}
