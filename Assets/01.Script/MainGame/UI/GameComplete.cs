using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameComplete : MonoBehaviour {

    public Text GameCompleteText;
    public Text GameFailText;
    // Use this for initialization
    void Start()
    {
        GameCompleteText.gameObject.SetActive(false);
        GameFailText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (MainGameManager.Instance.GetPlayer().IsComplete())
        {
            if(MainGameManager.Instance.GetPlayer().IsSuccess())
            {
                GameCompleteText.gameObject.SetActive(true);
            }

            else
            {
                GameFailText.gameObject.SetActive(true);
            }
            
        }
    }
}
