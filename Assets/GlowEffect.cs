﻿using UnityEngine;
using System.Collections;

public class GlowEffect : MonoBehaviour {

	//Component halo = GetComponent("Halo"); halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
	


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Pulsate()
	{
		while(true)
		{
			if(light. > 0.0f)
				light.intensity-= fade;
			yield return new WaitForEndOfFrame();
		}
	}
}
