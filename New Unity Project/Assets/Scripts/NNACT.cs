﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NNACT : MonoBehaviour {
	public Transform sucessBurst;
	public Transform lateBurst;
	public Transform failBurst;
	public Vector3 PSS;
	public LayerMask mylayermask;
	public GameObject line;
	public GameObject Slidelinehit;
	public GameObject NACT;
	public float getFinger;
	// Use this for initialization
	void Start () {
		RaycastHit hit;
		string nameOfLayer = "actlayer";
		LayerMask layer =  ~(1 << LayerMask.NameToLayer(nameOfLayer)); 
		Debug.DrawRay (transform.position, Vector3.up * 12f, Color.white, 10f);
		if(Physics.Raycast(transform.position, Vector3.up,out hit,12f,mylayermask)){
			if (hit.collider.gameObject.tag == "Note") {
				if (hit.collider.gameObject.GetComponent<CanclickOG> ().canclick == true) {
					if (hit.collider.gameObject.GetComponent<CanclickOG> ().startTime <= 2.92f && hit.collider.gameObject.GetComponent<CanclickOG> ().startTime >= 2.824f) {
						hit.collider.gameObject.SetActive (false);
						Debug.Log ("Hit!!");
						PSS = new Vector3 (hit.collider.transform.position.x, -1.848f, -3.559f);
						Instantiate (sucessBurst, PSS, sucessBurst.rotation);
						GM.totalCombo += 1;
						GM.highestcharmingcount += 1;
						if (GM.highestcombo <= GM.totalCombo) {
							GM.highestcombo += 1;
						}
						if (GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<notecontrol> ().totalScore < 100) {
							GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<notecontrol> ().totalScore += notecheck.charmingint;
						}
					} else if ((hit.collider.gameObject.GetComponent<CanclickOG> ().startTime <= 2.967537f && hit.collider.gameObject.GetComponent<CanclickOG> ().startTime > 2.92f) || (hit.collider.gameObject.GetComponent<CanclickOG> ().startTime >= 2.78f && hit.collider.gameObject.GetComponent<CanclickOG> ().startTime < 2.824)) {
						hit.collider.gameObject.SetActive (false);
						Debug.Log ("Hit!!");
						Instantiate (lateBurst, hit.collider.transform.position, lateBurst.rotation);
						GM.totalCombo += 1;
						if (GM.highestcombo <= GM.totalCombo) {
							GM.highestcombo += 1;
						}
						notecontrol.AllCharming = " ";
						if (GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<notecontrol> ().totalScore < 100) {
							GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<notecontrol> ().totalScore += notecheck.normint;
						}
					} else if (hit.collider.gameObject.GetComponent<CanclickOG> ().startTime <= 3.0f && hit.collider.gameObject.GetComponent<CanclickOG> ().startTime > 2.967537f) {
						hit.collider.gameObject.SetActive (false);
						Debug.Log ("Fail!!");
						Instantiate (failBurst, hit.point, failBurst.rotation);
						GM.totalCombo = (GM.totalCombo -= GM.totalCombo);
						notecontrol.AllCharming = " ";
						notecontrol.FullCombo = " ";
					}
				}
			} else if (hit.collider.gameObject.tag == "slideynote") {

			} else {
				Instantiate (NACT, transform.position, Quaternion.identity);

			}
	}
}
	
	// Update is called once per frame
	void Update () {
		
	}
}
