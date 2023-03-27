using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    Respawn respawnScript;

    // Start is called before the first frame update
    void Start()
    {
        respawnScript = GameObject.Find("GameManager").GetComponent<Respawn>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) 
        {
            //player dies
            respawnScript.respawn();
        }
    }
}
