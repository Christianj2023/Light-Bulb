using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sightBehavior : MonoBehaviour
{
    public GameObject player;
    public GameObject darkness;

    SpriteRenderer sprite;

    Color color = Color.clear;

    public float initialOpacity = 0.5f;
    public float initialRadius = 10f;

    public float opacity;
    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        darkness = GameObject.Find("Darkness");
        sprite = darkness.GetComponent<SpriteRenderer>();

        opacity = initialOpacity;
        radius = initialRadius;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    
    }

    void Update()
    {  
        transform.position = player.transform.position;

        if(radius > 1f)
        {
            radius -= Time.deltaTime;
        }
        else
        {
            radius = 10f;
        }
        
        setOpacity(opacity);
        setRadius(radius);
    }

    void setOpacity(float newOpacity)
    {
        sprite.color = new Color(0, 0, 0, newOpacity);
    }

    void setRadius(float newRadius)
    {
        transform.localScale = new Vector3(newRadius * 2, newRadius * 2, 1);
    }
}
