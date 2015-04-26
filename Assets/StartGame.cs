using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public GameObject scoreScreen;

	public GameObject ball;

	public GameObject world;

	public float startscreenSpeedupFactor = 10f;

	// Use this for initialization
	void Start () {

		// speed up movement for start screen
		SplineWalker sw = world.GetComponent<SplineWalker>();
		sw.duration /= startscreenSpeedupFactor;
	}
	
	// Update is called once per frame
	void Update () {
	
		bool down = Input.GetKeyDown(KeyCode.Space);
		
		if(down)
		{
			gameObject.SetActive(false);
			Debug.Log("starting game...");

			// enable ball
			ball.SetActive(true);

			// show scoreboard
			scoreScreen.SetActive(true);

			// restart path
			SplineWalker sw = world.GetComponent<SplineWalker>();
			sw.duration *= startscreenSpeedupFactor;
			sw.Start();
		}
	}
}
