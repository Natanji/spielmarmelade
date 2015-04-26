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

		Vector3 posBefore = transform.position;
		Vector3 parentPos = transform.parent.position;
		Quaternion parentRot = transform.parent.rotation;
		Vector3 front = new Vector3 ( 0.0f, 0.0f, 1.0f );
		Vector3 normal = parentRot * front;

		Vector3 projPoint = ProjectPointOnPlane (normal, parentPos - front * 1.0f, posBefore);
		transform.position = projPoint;

	}

	public static Vector3 ProjectPointOnPlane(Vector3 planeNormal, Vector3 planePoint, Vector3 point){
		
		float distance;
		Vector3 translationVector;
		
		//First calculate the distance from the point to the plane:
		distance = SignedDistancePlanePoint(planeNormal, planePoint, point);
		
		//Reverse the sign of the distance
		distance *= -1;
		
		//Get a translation vector
		translationVector = SetVectorLength(planeNormal, distance);
		
		//Translate the point to form a projection
		return point + translationVector;
	}

	public static float SignedDistancePlanePoint(Vector3 planeNormal, Vector3 planePoint, Vector3 point){
		
		return Vector3.Dot(planeNormal, (point - planePoint));
	}

	public static Vector3 SetVectorLength(Vector3 vector, float size){
		
		//normalize the vector
		Vector3 vectorNormalized = Vector3.Normalize(vector);
		
		//scale the vector
		return vectorNormalized *= size;
	}
}