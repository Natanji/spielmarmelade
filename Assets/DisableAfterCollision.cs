using UnityEngine;
using System.Collections;

public class DisableAfterCollision : MonoBehaviour {

	
	public bool enabled = true;
	public float disableDelay = 0.01f;
	public float enableDelay = 1.0f;

	public Renderer r;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void setTransparency(GameObject obj, float alpha)
	{
		//Renderer r = obj.GetComponentInChildren<Renderer>();
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
	
	void asyncDisable()
	{
		setTransparency (gameObject, 0.4f);
		setCollision (gameObject, false);
	}

	void asyncEnable()
	{		
		setTransparency (gameObject, 1f);
		setCollision (gameObject, true);
	}
	
	
	void OnCollisionEnter(Collision coll){
		
		if (coll.collider.gameObject.CompareTag ("ball")) {
			
			Invoke("asyncDisable", disableDelay);
			Invoke("asyncEnable", enableDelay);

		}
	}
}
