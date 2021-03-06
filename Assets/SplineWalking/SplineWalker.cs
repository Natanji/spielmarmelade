﻿using UnityEngine;

public class SplineWalker : MonoBehaviour {

	public BezierSpline spline;
	
	public float duration;

	public float start_time;

	public bool lookForward;

	public SplineWalkerMode mode;

	private float progress;
	private bool goingForward = true;

	bool enabled = true;
	
	public void Start()
	{
		progress = start_time / duration;
		Enable ();
	}

	public void Reset()
	{
		progress = 0f;
		Enable ();
	}

	private void Update () {
		if (!enabled)
			return;

		if (goingForward) {
			progress += Time.deltaTime / duration;
			if (progress > 1f) {
				if (mode == SplineWalkerMode.Once) {
					progress = 1f;
				}
				else if (mode == SplineWalkerMode.Loop) {
					progress -= 1f;
				}
				else {
					progress = 2f - progress;
					goingForward = false;
				}
			}
		}
		else {
			progress -= Time.deltaTime / duration;
			if (progress < 0f) {
				progress = -progress;
				goingForward = true;
			}
		}

		Vector3 position = spline.GetPoint(progress);
		transform.localPosition = position;
		if (lookForward) {
			transform.LookAt(position + spline.GetDirection(progress));
		}
	}

	public float getProgress(){
		return progress * duration;
	}
	
	public void Enable() {
		enabled = true;
	}

	public void Disable() {
		enabled = false;
	}
}