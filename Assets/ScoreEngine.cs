using UnityEngine;
using System.Collections;

public class ScoreEngine : MonoBehaviour {

	bool displayGameOverMessage = false;
	bool justLostLife = false;

	public GameObject gameOverScreen;
	public GameObject scoreboardScreen;
	public GameObject world;
	public GameObject victoryScreen;
	public AudioSource hitSound;
	public AudioSource breakSound;
	public AudioSource collisionSound;

	GameObject lastCollisionHand;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ResetBall()
	{
		float height = 14f; // TODO
		Vector3 parentPos = transform.parent.gameObject.transform.position + height*Vector3.up;
		
		transform.position = parentPos;
	}

	void ResetScores()
	{
		ScoreDisplay.hits = 0;
		ScoreDisplay.score = 0;
		ScoreDisplay.timer = 0.0f;
		ScoreDisplay.lifes = 3;
		ScoreDisplay.combo = 0;
	}

	void GameOverAsync()
	{
		ResetBall ();
		ResetScores ();

		gameOverScreen.SetActive (false);
		world.GetComponent<SplineWalker> ().Start ();
				
		GetComponent<SphereCollider>().enabled = true;
		GetComponent<Rigidbody>().useGravity = true;

		justLostLife = false;
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

	void VictoryEvent()
	{			
		Debug.Log("Collision with target... Victory!");

		scoreboardScreen.SetActive(false);
		victoryScreen.SetActive(true);
		
		GetComponent<SphereCollider>().enabled = false;

		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.useGravity = false;
		rb.constraints = RigidbodyConstraints.FreezeAll;

		// todo: pause pathwalker
		world.GetComponent<SplineWalker> ().Disable();
	}

	void LostLifeEvent()
	{		
		if(!justLostLife)
		{
			justLostLife = true;
			
			ScoreDisplay.lifes -= 1;
			ScoreDisplay.score -= 100;
			ScoreDisplay.combo = 0;
			
			//AudioSource audio = GetComponent<AudioSource>();
			//audio.Play();
			//Debug.Log ("collision!");
			collisionSound.Play ();
			
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

			// increase combo if using alternate hands
			if(lastCollisionHand == null || lastCollisionHand != coll.collider.gameObject)
			{
				lastCollisionHand = coll.collider.gameObject;
				ScoreDisplay.combo += 1;
			}
			else
			{
				ScoreDisplay.combo = 0;
			}
			
			ScoreDisplay.hits += 1;
			ScoreDisplay.score += 10 * ScoreDisplay.combo;

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

		// victory if reaching target
		if (coll.collider.gameObject.CompareTag ("target")) {
			VictoryEvent();
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
