using UnityEngine;
using System.Collections;

public class AutoCameraControl : MonoBehaviour {
	
	
	GameObject ballGameObject;
	Camera cameraHdl;
	
	
	// Use this for initialization
	void Start () {
		ballGameObject = GameObject.FindWithTag ("ball");
		cameraHdl = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 ballPos = ballGameObject.transform.position;
		Vector3 thisPos = transform.position;
		
		Vector3 direction = ballPos - thisPos;
		direction.x = 0; // do not look left or right
		
		Vector3 ballPosOnScreen = cameraHdl.WorldToViewportPoint (ballPos);
		//Debug.Log (ballPosOnScreen);
		
		// only if looking up and ball near top screen boundary
		if (direction.y > 0 ){//&& ballPosOnScreen.y > 0.8) { 
			
			float angle = 90f/2f*(9f/16f);
			
			//Vector3 threshold = cameraHdl.ViewportToWorldPoint(new Vector3(0.5f, 0.8f, direction.magnitude));
			Quaternion rotation = new Quaternion();
			rotation.eulerAngles = new Vector3(angle, 0, 0);
			
			Vector3 adjustedDirection = rotation*direction;
			
			Quaternion lookAtRotation = Quaternion.LookRotation (adjustedDirection, Vector3.up);
			
			transform.rotation = lookAtRotation;
		} 
	}
}
