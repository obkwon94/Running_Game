using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameComplete : MonoBehaviour {

    public Text GameCompleteText;
    // Use this for initialization
    void Start()
    {
        GameCompleteText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (MainGameManager.Instance.GetPlayer().IsComplete())
        {
            if(MainGameManager.Instance.GetPlayer().IsSuccess())
            {

            }

            else
            {

            }
            GameCompleteText.gameObject.SetActive(true);
        }
    }
}
