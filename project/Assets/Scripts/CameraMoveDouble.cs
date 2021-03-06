﻿using UnityEngine;
using System.Collections;

public class CameraMoveDouble : MonoBehaviour {
	
	public GameObject ball1;
	public GameObject ball2;
	public float radius;
	public float angle;
	
	private Vector3 center;
	private float newRadius;//we use when the balls are far between them. 
	private Vector3 distances;
	private Vector3 save_center;
	
	// Use this for initialization
	void Start () {
		newRadius = radius;
	}
	
	// LateUpdate is called after all Update functions have been called.
	void LateUpdate () {
		if (ball1.activeSelf && ball2.activeSelf)//check if there are one or two ball active.
			cameraTwoBalls ();
		else if (ball1.activeSelf)
			cameraOneBall (ball1);
		else if (ball2.activeSelf)
			cameraOneBall (ball2);
		else
			center = save_center;

		Vector3 offsetPos = new Vector3(0, Mathf.Sin ((angle)*Mathf.Deg2Rad)*newRadius, Mathf.Cos ((angle)*Mathf.Deg2Rad) * -newRadius);
		transform.position = center + offsetPos;
		transform.eulerAngles = new Vector3(angle,0,0);

		save_center = center;
	}

	//if there are only one ball, the center is this ball
	private void cameraOneBall(GameObject ball){
			center = ball.transform.position;
	}

	//if there are two ball, the center is the middle of hte two ball.
	private void cameraTwoBalls(){
		distances = ball1.transform.position - ball2.transform.position;
		newRadius = Mathf.Sqrt(distances.x * distances.x + distances.y * distances.y + distances.z * distances.z);
		if (newRadius < radius) {
			newRadius = radius;
		}
		center = (ball1.transform.position + ball2.transform.position)/2 ;
	}
}
