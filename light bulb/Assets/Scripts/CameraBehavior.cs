using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    CameraMove cameraScript;
    
    float[] initialState;
    float[] cameraState;
    
    
    // Start is called before the first frame update
    void Start()
    {
        cameraScript = GameObject.Find("Main Camera").GetComponentInChildren<CameraMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
