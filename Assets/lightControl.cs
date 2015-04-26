using UnityEngine;
using System.Collections;

public class lightControl : MonoBehaviour {

	protected Renderer r;

	// Use this for initialization
	void Start () {

		r = gameObject.GetComponentInChildren<Renderer>();

		r.material.SetColor ("_EmissionColor", Color.red);
	}
	
	// Update is called once per frame
	void Update () {


		r.material.SetColor ("_EmissionColor", Color.red);
	}
}
