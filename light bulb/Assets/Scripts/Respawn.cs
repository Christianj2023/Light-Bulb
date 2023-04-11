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
    public GameObject enemyParent;
    
    public float outOfBoundsY = -8f;

    public List<Transform> recharges = new List<Transform>();

    public Vector3 spawnPoint;

    int index = -1;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        sight = GameObject.Find("Sight");
        
        playerMovementScript = player.GetComponent<PlayerMovement>();
        sightBehaviorScript = sight.GetComponent<SightBehavior>();

        rechargeParent = GameObject.Find("Recharges");
        collectibleParent = GameObject.Find("Collectibles");
        enemyParent = GameObject.Find("Enemies");

        spawnPoint = playerMovementScript.initialPosition;

        foreach(Transform recharge in rechargeParent.transform)
        {
            recharges.Add(recharge);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y < outOfBoundsY)
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
        resetEnemies();
    }

    void resetDarkness()
    {
        sightBehaviorScript.resetDarkness();
    }

    void resetPlayer()
    {
        player.transform.position = spawnPoint;

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

    void resetEnemies()
    {
        foreach(Transform enemy in enemyParent.transform)
        {
            enemy.GetComponent<EnemyMove>().reset();
            Debug.Log("naerisot");
        }
    }

    public void setSpawn(Vector3 rechargePosition)
    {
        spawnPoint = rechargePosition;
    }
}
