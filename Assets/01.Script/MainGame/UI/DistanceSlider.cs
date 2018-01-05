using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceSlider : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float maxDistance = MainGameManager.Instance.GetPlayer().GetMaxDistance();
        float currentDistance = MainGameManager.Instance.GetPlayer().GetCurrentDistance();
        float rate = currentDistance / maxDistance;
        gameObject.GetComponent<Slider>().value = rate;
    }
}
