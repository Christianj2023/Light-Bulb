using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recharge : MonoBehaviour
{
    SightBehavior sightBehaviorScript;
    
    // Start is called before the first frame update
    void Start()
    {
        sightBehaviorScript = GameObject.Find("Sight").GetComponent<SightBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) 
        {
            sightBehaviorScript.resetDarkness();
            gameObject.SetActive(false);
        }
    }
}
