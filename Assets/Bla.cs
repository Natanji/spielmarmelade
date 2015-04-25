using UnityEngine;
using System.Collections;
/*
public class Bla : MonoBehaviour {

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		Vector3 force1 = transform.forward * 10.0f * Input.GetAxis("Vertical");
		Vector3 force2 = transform.right * 10.0f * Input.GetAxis("Horizontal");
		GetComponent<Rigidbody>().AddForce(force1 + force2);
	}
}
*/
public class Bla : MonoBehaviour {
	
	Rigidbody rb;
	
	// Use this for initialization
	void Start () {
		
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		bool down = Input.GetKeyDown(KeyCode.Space);
		//bool held = Input.GetKey(KeyCode.Space);
		//bool up = Input.GetKeyUp(KeyCode.Space);
		
		if(down)
		{
			Vector3 v = new Vector3(0, 40, 0);
			rb.AddForce(v);
			
			//transform.Translate(v);
			
			
		}
		
		
	}
}