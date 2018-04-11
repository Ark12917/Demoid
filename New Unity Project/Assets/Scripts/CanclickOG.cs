﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanclickOG : MonoBehaviour {
	public bool canclick=false;
	public float startTime=3f;

	// Use this for initialization
	void Start () {
		
	}
	public IEnumerator checkclick(){
		yield return new WaitForSeconds (0.0f);
		canclick = true;
	}
	// Update is called once per frame
	void Update () {
		if (canclick) {
			startTime -= Time.deltaTime;
			//print (startTime);
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (canclick == false&&gameObject.activeSelf==true) {
			try {
				StartCoroutine (checkclick ());
			} catch {
			}
		} else {
		}
	}
	void OnDisable() {
		canclick = false;
		startTime = 3.0f;
	}
}
