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
		//direction.x = 0; // do not look left or right
		
		//Vector3 ballPosOnScreen = cameraHdl.WorldToViewportPoint (ballPos);
		//Debug.Log (ballPosOnScreen);
			
		float angle = 90f/2f*(9f/16f);
			
		//Vector3 threshold = cameraHdl.ViewportToWorldPoint(new Vector3(0.5f, 0.8f, direction.magnitude));
		Quaternion rotation = new Quaternion();

		Quaternion parentRotation = transform.parent.rotation;

		rotation.eulerAngles = new Vector3(angle, 0, 0);
			
		Vector3 adjustedDirection = rotation*direction;
			
		Quaternion lookAtRotation = Quaternion.LookRotation (adjustedDirection, Vector3.up);

		if (direction.y > 0 ){
			//transform.rotation = lookAtRotation;
		}
	}
}
