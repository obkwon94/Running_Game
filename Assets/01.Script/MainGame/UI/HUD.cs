using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text WeightText;
    public Text MaxSpeedText;
    public Text CurrentSpeedText;
    public Text DoubleJumpText;
    public Text CurrentDistanceText;
    public Text RemainDistanceText;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float maxDistance = MainGameManager.Instance.GetPlayer().GetMaxDistance();
        float distance = MainGameManager.Instance.GetPlayer().GetCurrentDistance();
        int remainDistance = (int)(maxDistance - distance);

        WeightText.text = "Weight" + MainGameManager.Instance.GetPlayer().GetCurrentWeight() + " / " + MainGameManager.Instance.GetPlayer().GetGoalWeight();
        MaxSpeedText.text = "MaxSpeed" + MainGameManager.Instance.GetPlayer().GetMaxSpeed();
        CurrentSpeedText.text = "Speed" + MainGameManager.Instance.GetPlayer().GetCurrentSpeed();
        CurrentDistanceText.text = "Distance\n" + MainGameManager.Instance.GetPlayer().GetCurrentDistance();
        RemainDistanceText.text = "RemainDistance\n" + remainDistance;

        if (MainGameManager.Instance.GetPlayer().CanDoubleJump())
        {
            DoubleJumpText.text = "DoubleJump ON";
        }
        else
        {
            DoubleJumpText.text = "DoubleJump OFF";
        }
    }
}
