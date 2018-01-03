using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreator : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (false == _isCreate)
            return;

        //거리 기반
        float distance = transform.position.x - _prevBlockObject.transform.position.x;
        if(_intervalDistance <= distance)
        {
            _prevBlockObject = CreateBlock();
        }
	}

    //State

    bool _isCreate = false;

    public void StartCreate()
    {
        _isCreate = true;

        _prevBlockObject = CreateBlock();
    }

    // Blocks
    public GameObject BlockPrefabs;
    public GameObject CoinPrefabs_1;
    public GameObject CoinPrefabs_2;

    GameObject _prevBlockObject;

    //for test
    public float _intervalDistance = 10.0f;

    GameObject CreateBlock()
    {
        
        GameObject blockObject = GameObject.Instantiate(BlockPrefabs);
        blockObject.transform.position = transform.position;
   
        GameObject coinObject_1;
        GameObject coinObject_2;

        int selectCoin = Random.Range(0, 1000);
        if(selectCoin < 500)
        {
            coinObject_1 = GameObject.Instantiate(CoinPrefabs_1);
            coinObject_2 = GameObject.Instantiate(CoinPrefabs_2);
        }
        else
        {
            coinObject_1 = GameObject.Instantiate(CoinPrefabs_2);
            coinObject_2 = GameObject.Instantiate(CoinPrefabs_1);
        }

        coinObject_1.transform.position = new Vector2(transform.position.x, 0.7f);
        coinObject_2.transform.position = new Vector2(transform.position.x, 3.5f);

        int randValue = Random.Range(0, 1000);
        if(randValue < 300)
        {
            blockObject.transform.position = new Vector2(blockObject.transform.position.x, 0.4f);
            coinObject_1.transform.position = transform.position;
        }

        return blockObject;
    }
}