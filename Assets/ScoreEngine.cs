using UnityEngine;
using System.Collections;

public class ScoreEngine : MonoBehaviour {

	GameObject lastCollisionHand;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void setTransparency(GameObject obj, float alpha)
	{
		Renderer r = obj.GetComponent<Renderer>();
		//r.enabled = true;
		
		Color oldColor = r.material.color;
		Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alpha);   
		
		r.material.color = newColor;
		
		//Debug.Log ("transparency changed");
	}

	void setCollision(GameObject obj, bool enabled)
	{
		CapsuleCollider c = obj.GetComponent<CapsuleCollider> ();

		c.enabled = enabled;
	}
	
	void OnCollisionEnter(Collision coll){
		
		if (coll.collider.gameObject.CompareTag ("hand")) {

			if(lastCollisionHand == null || lastCollisionHand != coll.collider.gameObject)
			{
				ScoreDisplay.hits += 1;
				ScoreDisplay.score += 10;

				AudioSource audio = GetComponent<AudioSource>();
				audio.Play();


				if(lastCollisionHand != null)
				{
					setTransparency(lastCollisionHand, 1.0f);
					setCollision(lastCollisionHand, true);
				}

				lastCollisionHand = coll.collider.gameObject;

				setTransparency(lastCollisionHand, 0.4f);
				setCollision(lastCollisionHand, false);
			}
			//Debug.Log ("collision!");
		}

		// reset score if ball falls on floor
		if (coll.collider.gameObject.CompareTag ("floor")) {
			ScoreDisplay.hits = 0;
			ScoreDisplay.score = 0;
			ScoreDisplay.timer = 0.0f;
		}
	}
	
}
