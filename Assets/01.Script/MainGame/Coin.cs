using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float addHP = 0.0f;
    public float addWeight = 0.0f;

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
            MainGameManager.Instance.GetPlayer().AddWeight(addWeight);
            MainGameManager.Instance.GetPlayer().IncreaseHP(addHP);
            GameObject.Destroy(gameObject);
        }
    }
}
