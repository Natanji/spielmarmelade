using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VictoryScoreDisplay : MonoBehaviour {

	public Text text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Final Score: " + ScoreDisplay.score; 
	}
}
