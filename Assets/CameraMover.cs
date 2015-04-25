using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float v = Input.GetAxis("Vertical");
		
		transform.Translate (0, 0, v * Time.deltaTime);
		
	}
}
