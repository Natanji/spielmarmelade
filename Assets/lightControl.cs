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
		float maxProgress = world.GetComponent<SplineWalker> ().duration;

		float factor = (progress / maxProgress * (Mathf.Sin(progress*2.0f) + 1.0f) * 0.25f) + (progress / maxProgress * 0.5f);

		Color eColor = new Color (factor, 0.0f, 0.0f);

		light.color = eColor;
		r.material.SetColor ("_EmissionColor", eColor);
	}
}
