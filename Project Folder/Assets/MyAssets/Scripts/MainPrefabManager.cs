using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPrefabManager : MonoBehaviour
{
    public OrderManager orderManager;
	public GameManager gameManager;

	void Start()
	{
		if(orderManager == null)
		{
			orderManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<OrderManager>();
		}
		if(gameManager == null)
		{
			gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		}
	}

    void OnDestroy()
    {
		if(orderManager.isJustLoaded == true)
		{
			gameManager.currentTime = 60;
			orderManager.isJustLoaded = false;
		}
    }
}
