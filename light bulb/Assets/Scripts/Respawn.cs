using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject player;
    public GameObject sight;
    
    public PlayerMovement playerMovementScript;
    public SightBehavior sightBehaviorScript;

    public GameObject rechargeParent;
    public GameObject collectibleParent;
    
    public float outOfBoundsY = -8f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        sight = GameObject.Find("Sight");
        
        playerMovementScript = player.GetComponent<PlayerMovement>();
        sightBehaviorScript = sight.GetComponent<SightBehavior>();

        rechargeParent = GameObject.Find("Recharges");
        collectibleParent = GameObject.Find("Collectibles");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < outOfBoundsY)
        {
            respawn();
        }
    }

    public void respawn()
    {
        resetDarkness();
        resetPlayer();
        resetCollectibles();
        resetRecharges();
    }

    void resetDarkness()
    {
        sightBehaviorScript.resetDarkness();
    }

    void resetPlayer()
    {
        player.transform.position = playerMovementScript.initialPosition;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    void resetCollectibles()
    {
        foreach(Transform collectible in collectibleParent.transform)
        {
            collectible.gameObject.SetActive(true);
        }
    }

    void resetRecharges()
    {
        foreach(Transform recharge in rechargeParent.transform)
        {
            recharge.gameObject.SetActive(true);
        }
    }
}
