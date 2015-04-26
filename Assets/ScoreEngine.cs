﻿using UnityEngine;
using System.Collections;

public class ScoreEngine : MonoBehaviour {

	bool displayGameOverMessage = false;
	bool justLostLife = false;

	public GameObject gameOverScreen;
	public GameObject scoreboardScreen;
	public GameObject world;
	public AudioSource hitSound;
	public AudioSource breakSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ResetBall()
	{
		float height = 10f; // TODO
		Vector3 parentPos = transform.parent.gameObject.transform.position + height*Vector3.up;
		
		transform.position = parentPos;
	}

	void ResetScores()
	{
		ScoreDisplay.hits = 0;
		ScoreDisplay.score = 0;
		ScoreDisplay.timer = 0.0f;
		ScoreDisplay.lifes = 3;
	}

	void GameOverAsync()
	{
		ResetBall ();
		ResetScores ();

		gameOverScreen.SetActive (false);
		world.GetComponent<SplineWalker> ().Reset ();

		displayGameOverMessage = false;
	}

	void LostLifeAsync()
	{
		ResetBall ();
		
		GetComponent<SphereCollider>().enabled = true;
		GetComponent<Rigidbody>().useGravity = true;

		justLostLife = false;
	}

	IEnumerator FlashingBall() {

		MeshRenderer mr = GetComponent<MeshRenderer> ();

		for (int i = 0; i < 10; i++) {

			if(i % 2 == 0)
			{
				mr.enabled = false;
			}
			else
			{
				mr.enabled = true;
			}

			yield return new WaitForSeconds(.2f);
		}
	}

	void GameOverEvent()
	{
		
		if(!displayGameOverMessage)
		{
			displayGameOverMessage = true;

			breakSound.Play();

			Debug.Log("Game over - resetting in 2 seconds...");
			
			gameOverScreen.SetActive(true);
			
			Invoke("GameOverAsync", 2f);
		}
	}

	void LostLifeEvent()
	{		
		if(!justLostLife)
		{
			justLostLife = true;
			
			ScoreDisplay.lifes -= 1;
			ScoreDisplay.score -= 10;
			
			//AudioSource audio = GetComponent<AudioSource>();
			//audio.Play();
			//Debug.Log ("collision!");
			
			Debug.Log("collision with obstacle!");
			
			GetComponent<SphereCollider>().enabled = false;
			GetComponent<Rigidbody>().useGravity = false;
			
			StartCoroutine(FlashingBall());
			
			if(ScoreDisplay.lifes > 0)
				Invoke("LostLifeAsync", 2f);
			else
				GameOverEvent();
		}
	}
	
	void OnCollisionEnter(Collision coll){

		// on collision with hand
		if (coll.collider.gameObject.CompareTag ("hand")) {

			ScoreDisplay.hits += 1;
			ScoreDisplay.score += 10;

			//AudioSource audio = GetComponent<AudioSource>();
			//audio.Play();
			hitSound.Play();
			//Debug.Log ("collision!");
		}

		// on collision with obstacle
		if (coll.collider.gameObject.CompareTag ("obstacle")) {
			LostLifeEvent();
		}

		// reset score if ball falls on floor
		if (coll.collider.gameObject.CompareTag ("floor")) {
			GameOverEvent();
		}
	}

//	void OnGUI() {
//
//		GUIStyle style = new GUIStyle ();
//		style.fontSize = 40;
//		style.alignment = TextAnchor.MiddleCenter;
//		//style.
//
//		if(displayGameOverMessage)
//			GUI.Label(new Rect(Screen.width * 0.5f - 50f, Screen.height * 0.5f - 10f, 100f, 20f), "GAME OVER", style);
//
//	}
	
}
