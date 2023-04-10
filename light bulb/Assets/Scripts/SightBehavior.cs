using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightBehavior : MonoBehaviour
{
    public GameObject firefly;
    public GameObject darkness;

    SpriteRenderer sprite;

    Color color = Color.clear;

    public float startingRadius = 4f;

    public float initialOpacity = 0.5f;
    public float initialRadius = 10f;

    public float minimumRadius = 3f;

    public float opacity;
    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        firefly = GameObject.Find("Firefly");
        darkness = GameObject.Find("Darkness");
        sprite = darkness.GetComponent<SpriteRenderer>();
        radius = startingRadius;
        opacity = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void Update()
    {  
        transform.position = firefly.transform.position;

        if(radius > minimumRadius)
        {
            radius -= Time.deltaTime / 3;
        }
        
        setOpacity(opacity);
        setRadius(radius);
    }

    public void setOpacity(float newOpacity)
    {
        sprite.color = new Color(0, 0, 0, newOpacity);
    }

    public void setRadius(float newRadius)
    {
        transform.localScale = new Vector3(newRadius * 2, newRadius * 2, 1);
    }

    public void resetDarkness()
    {
        radius = initialRadius;
        opacity = initialOpacity;
    }
}
