using UnityEngine;
using System.Collections;

public class GlowEffect : MonoBehaviour {


	


	// Use this for initialization
	void Start () {
		//StartCoroutine(Pulsate());
		(gameObject.GetComponent ("Halo") as Behaviour).enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Pulsate()
	{
		float size = 1.0f;

		Component halo = GetComponent("Halo"); 


		while(true)
		{
			size += 0.01f;
			halo.GetType().GetProperty("size").SetValue(halo, size, null);

			yield return new WaitForEndOfFrame();
		}
	}
}
