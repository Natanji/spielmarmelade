using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
	
	public static int hits;
	public static int score;
	public static float timer = 0;
	public static int lifes;
	public static int combo;
	
	public Text text;
	
	// Use this for initialization
	void Start () {
		
		hits = 0;
		score = 0;
		lifes = 3;
		combo = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		
		text.text = "Score: " + score + 
			"\nHits: " + hits + 
				"\nCombo: " + combo + 
				"\nTime: " + Mathf.RoundToInt(timer)+ 
				"\nLifes: " + lifes;
		
		
	}
}
