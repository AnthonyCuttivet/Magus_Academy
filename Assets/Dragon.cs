using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    SpriteRenderer sprite;
    float timeBeforeFade = 1;
    public float timeToFadeIn = 5f;
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBeforeFade <= 0){
            Color newColor = sprite.color;
            newColor.a += Time.deltaTime * ( 1 / timeToFadeIn);
            newColor.r += Time.deltaTime * ( 1 / timeToFadeIn);
            newColor.g += Time.deltaTime * ( 1 / timeToFadeIn);
            newColor.b += Time.deltaTime * ( 1 / timeToFadeIn);
            sprite.color = newColor;
        }
        timeBeforeFade -= Time.deltaTime;

    }
}
