using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightBehavior : MonoBehaviour
{
    public GameObject firefly;
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
        firefly = GameObject.Find("Firefly");
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
        transform.position = firefly.transform.position;

        if(radius > 1f)
        {
            radius -= Time.deltaTime / 2;
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
