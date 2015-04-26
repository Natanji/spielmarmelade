using UnityEngine;
using System.Collections;
using Leap;

public class TestHand : MonoBehaviour {

	protected Controller leap_controller_;
	public Rigidbody rb;
	public bool rightHand = false;
	public float mousePaddleDistance = 3.0f;

	void Awake() {
		leap_controller_ = new Controller();
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();

		Quaternion parentRot = transform.parent.gameObject.transform.rotation;
		Vector3 parentPos = transform.parent.gameObject.transform.position;
		Vector3 correctionUp = new Vector3 (0.0f, 5.0f, 0.0f);
		Vector3 right = new Vector3( 1.0f, 0.0f, 0.0f);

		right = parentRot * right;

		Vector3 correction = right * -1.0f * mousePaddleDistance;
		if( rightHand )
			correction = correction * -1.0f;

		transform.position = parentPos + (parentRot * correctionUp) + correction;
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		Frame frame = leap_controller_.Frame(); // controller is a Controller object
		HandList hands = frame.Hands;

		Hand hand;
		if (rightHand) {
			hand = hands.Rightmost;
		} else {
			hand = hands.Leftmost;
		}
	
		Vector3 parentPos = transform.parent.gameObject.transform.position;
		Quaternion parentRot = transform.parent.gameObject.transform.rotation;

		if (hand.IsValid) {
			Vector3 palmPos = hand.PalmPosition.ToUnity () * 0.02f;
			Quaternion handRotation = hand.Basis.Rotation ();

			Quaternion newRotation = new Quaternion ();
			newRotation.eulerAngles = new Vector3 (0.0f, 0.0f, handRotation.eulerAngles.z + 90.0f);

			Quaternion leftHandCorrection = new Quaternion();
			if( !rightHand ) {
				leftHandCorrection.eulerAngles = new Vector3( 0.0f, 0.0f, 0.0f );
			} else {
				leftHandCorrection.eulerAngles = new Vector3( 0.0f, 0.0f, 0.0f );	
			}

			palmPos.z = 0.0f;
			rb.MovePosition (parentPos + parentRot * palmPos);
			rb.MoveRotation (parentRot * newRotation * leftHandCorrection);
		} else { // use mouse
			float mousex = Input.GetAxis ("Mouse X") * Time.deltaTime * 30.0f;
			float mousey = Input.GetAxis ("Mouse Y") * Time.deltaTime * 30.0f;

			Vector3 right = new Vector3( 1.0f, 0.0f, 0.0f);
			Vector3 up = new Vector3( 0.0f, 1.0f, 0.0f);

			right = parentRot * right;
			up = parentRot * up;

			Vector3 correction = right * -1.0f * mousePaddleDistance;
			if( rightHand )
				correction = correction * -1.0f;

			Vector3 newPosition = (transform.position - transform.parent.position - correction) + mousey * up + mousex * right;

			Quaternion newRotation = new Quaternion ();
			newRotation.eulerAngles = new Vector3 (0.0f, 0.0f, 90.0f);

			rb.MovePosition (parentPos + newPosition + correction);
			rb.MoveRotation (parentRot * newRotation);

			//Debug.Log("using mouse now...");
		}
		//Debug.Log (palmPos.ToString ());
	}
}
