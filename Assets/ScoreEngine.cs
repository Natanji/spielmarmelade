﻿using UnityEngine;
using System.Collections;

public class ScoreEngine : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	
	void OnCollisionEnter(Collision coll){
		
		if (coll.collider.gameObject.CompareTag ("hand")) {

			ScoreDisplay.hits += 1;
			ScoreDisplay.score += 10;

			AudioSource audio = GetComponent<AudioSource>();
			audio.Play();
			//Debug.Log ("collision!");
		}

		// reset score if ball falls on floor
		if (coll.collider.gameObject.CompareTag ("floor")) {
			ScoreDisplay.hits = 0;
			ScoreDisplay.score = 0;
			ScoreDisplay.timer = 0.0f;
		}
	}
	
}
