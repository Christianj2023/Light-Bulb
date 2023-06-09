using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float leftBound;
    public float rightBound;

    public float startPosition;

    public float enemySpeed = 3f;

    public bool movingRight = true;

    float tempX;
    
    // Start is called before the first frame update
    void Start()
    {
        leftBound = transform.position.x - 5;
        rightBound = transform.position.x + 5;

        startPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        tempX = transform.position.x;

        if(movingRight)
        {
            tempX += enemySpeed * Time.deltaTime;
        }
        else
        {
            tempX -= enemySpeed * Time.deltaTime;
        }

        if(tempX > rightBound)
        {
            movingRight = false;
            transform.Rotate(0f, 180f, 0f);
            tempX = rightBound;
        }
        else if(tempX < leftBound)
        {
            movingRight = true;
            transform.Rotate(0f, -180f, 0f);
            tempX = leftBound;
        }

        transform.position = new Vector3(tempX, transform.position.y, 0);
    }

    public void reset()
    {
        if(!movingRight)
        {
            movingRight = true;
            transform.Rotate(0f, -180f, 0f);
        }

        transform.position = new Vector3(startPosition, transform.position.y, 0);
    }
}
