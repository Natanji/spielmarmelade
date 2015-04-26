using UnityEngine;
using System.Collections;

public class lightControl : MonoBehaviour {

	protected Renderer r;
	public GameObject world;
	public Light light;

	// Use this for initialization
	void Start () {

		r = gameObject.GetComponentInChildren<Renderer>();

		r.material.SetColor ("_EmissionColor", Color.black);
	}
	
	// Update is called once per frame
	void Update () {
		float progress = world.GetComponent<SplineWalker> ().getProgress();

		Color eColor = new Color (progress / 120.0f, 0.0f, 0.0f);

		light.color = eColor;
		r.material.SetColor ("_EmissionColor", eColor);
	}
}
