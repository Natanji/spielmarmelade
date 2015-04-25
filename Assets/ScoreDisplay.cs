using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
	
	public static int hits;
	public static int score;
	public static float timer = 0;
	
	Text text;
	
	// Use this for initialization
	void Start () {
		
		hits = 0;
		score = 0;
		
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		
		text.text = "Score: " + score + 
			"\nHits: " + hits + 
				"\nTime: " + Mathf.RoundToInt(timer);
		
		
	}
}
