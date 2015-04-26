﻿using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public GameObject scoreScreen;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		bool down = Input.GetKeyDown(KeyCode.Space);
		
		if(down)
		{
			gameObject.SetActive(false);
			Debug.Log("starting game...");

			// show scoreboard
			scoreScreen.SetActive(true);
		}
	}
}
