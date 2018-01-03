using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //Vector2 _velocity = Vector2.zero;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if("Player" == collision.tag)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
