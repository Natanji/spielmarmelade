using UnityEngine;
using System.Collections;
using Leap;

public class TestHand : MonoBehaviour {

	protected Controller leap_controller_;
	public Rigidbody rb;
	public bool rightHand = false;

	void Awake() {
		leap_controller_ = new Controller();
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
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

		if (hand.IsValid) {
			Vector3 palmPos = hand.PalmPosition.ToUnity () * 0.02f;
			Quaternion handRotation = hand.Basis.Rotation();

			Quaternion newRotation = new Quaternion();
			newRotation.eulerAngles = new Vector3( 0.0f, 0.0f, handRotation.eulerAngles.z + 90.0f );

			palmPos.z = 0.0f;
			rb.MovePosition( palmPos );
			rb.MoveRotation( newRotation );
		}
		//Debug.Log (palmPos.ToString ());
	}
}
