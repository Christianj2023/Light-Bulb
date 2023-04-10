using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    GameObject player;
    
    public float cameraX;
    public float cameraY;
    public Vector3 cameraCoords;

    public float distanceX;
    public float distanceY;    

    public float targetX;
    public float targetY;

    public float lerpAmount = 10f;

    public float cameraSpeedX;

    public Vector3 initialCameraPosition = new Vector3(-6.5f, 0.5f, -10);

    public float levelLeftBound = -6.5f;
    public float levelRightBound = 22.5f;
    public float levelBottomBound = 0.5f;
    public float levelTopBound = 0f;

    public float playerLeftBound = -7f;
    public float playerRightBound = 7f;
    public float playerBottomBound = -4f;
    public float playerTopBound = 4f;

    public float followLeftBound = 2f;
    public float followRightBound = 4f;
    public float followBottomBound = -3f;
    public float followTopBound = 3f;
    
    void Start()
    {
        player = GameObject.Find("Player");
        transform.position = initialCameraPosition;
        cameraCoords = initialCameraPosition;
        cameraX = cameraCoords.x;
        cameraY = cameraCoords.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Debug.Log($"{player.transform.position.x}");
        
        distanceX = player.transform.position.x - cameraX;

        targetX = player.transform.position.x + 3;
        //Mathf.Clamp(cameraX, player.transform.position.x + followLeftBound, player.transform.position.x + followRightBound);
        cameraX = Mathf.SmoothDamp(cameraX, targetX, ref cameraSpeedX, .05f);

        //cameraX = Mathf.Clamp(cameraX, player.transform.position.x + playerLeftBound, player.transform.position.x + playerRightBound);
        
        cameraX = Mathf.Clamp(cameraX, levelLeftBound, levelRightBound);
        
        cameraCoords.x = cameraX;
        cameraCoords.y = cameraY;
        
        transform.position = cameraCoords;

        Debug.Log($"inlevel {withinHorizontalLevelBounds()} smoothing {withinHorizontalFollowBounds()}");
    }
    
    bool withinHorizontalLevelBounds()
    {
        return cameraX >= levelLeftBound && cameraX <= levelRightBound;
    }

    bool withinVerticalLevelBounds()
    {
        return player.transform.position.y >= levelBottomBound && player.transform.position.y <= levelTopBound;
    }
    
    bool withinHorizontalFollowBounds()
    {
        return distanceX >= followLeftBound && distanceX <= followRightBound;
    }

    bool withinVerticalFollowBounds()
    {
        return distanceY >= followBottomBound && distanceY <= followTopBound;
    }

}
