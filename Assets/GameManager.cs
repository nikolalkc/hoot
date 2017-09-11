using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameObject leftHand, rightHand;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//leva ruka
		if (Input.GetMouseButtonDown(0)) {
			if (leftHand.activeInHierarchy) {
				leftHand.SetActive(false);
			}
			else{
				leftHand.SetActive(true);
			}
		}

		//desna ruka
		if (Input.GetMouseButtonDown(1)) {
			if (rightHand.activeInHierarchy) {
				rightHand.SetActive(false);
			}
			else{
				rightHand.SetActive(true);
			}
		}
	}
}
