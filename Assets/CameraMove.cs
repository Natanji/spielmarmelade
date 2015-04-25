using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 translation = new Vector3(0.0f, 0.0f, 0.01f);
		transform.Translate ( translation );
		transform.Rotate( new Vector3(0.0f, 0.1f, 0.0f) );
	}
}
