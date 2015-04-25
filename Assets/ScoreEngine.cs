using UnityEngine;
using System.Collections;

public class ScoreEngine : MonoBehaviour {

	bool displayGameOverMessage = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ResetBall()
	{
		float height = 10f;
		Vector3 parentPos = transform.parent.gameObject.transform.position + height*Vector3.up;
		
		transform.position = parentPos;
	}

	void ResetScores()
	{
		ScoreDisplay.hits = 0;
		ScoreDisplay.score = 0;
		ScoreDisplay.timer = 0.0f;
	}

	void GameOver()
	{
		ResetBall ();
		ResetScores ();

		displayGameOverMessage = false;
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

			if(!displayGameOverMessage)
			{
				Debug.Log("Game over - resetting in 2 seconds...");

				displayGameOverMessage = true;

				Invoke("GameOver", 2f);
			}
		}
	}

	void OnGUI() {

		GUIStyle style = new GUIStyle ();
		style.fontSize = 40;
		style.alignment = TextAnchor.MiddleCenter;
		//style.

		if(displayGameOverMessage)
			GUI.Label(new Rect(Screen.width * 0.5f - 50f, Screen.height * 0.5f - 10f, 100f, 20f), "GAME OVER", style);

	}
	
}
