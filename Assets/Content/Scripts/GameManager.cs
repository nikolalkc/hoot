using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public GameObject leftHand, rightHand;
	public Text Objective;
	public string[] objectives;
	public int objective_index = 0;
	Collider CurrentObjectiveCollider;
	// Use this for initialization
	void Start () {
		Objective.text = objectives[objective_index];
	}

	
	// Update is called once per frame
	void Update () {
		//leva ruka
		/*if (Input.GetMouseButtonDown(0)) {
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
		*/

		if (leftHand.activeSelf) {
			if (Input.GetMouseButtonDown (0)) {
				CompleteActiveTask ();
			}
		}
	}

	void OnTriggerEnter(Collider col) {
		//print (col.tag);
		if (col.tag == "task") {
			SetHandsActive (true);
		}
		CurrentObjectiveCollider = col;
	}

	void OnTriggerExit(Collider col) {
		if (col.tag == "task") {
			SetHandsActive (false);
		}
		CurrentObjectiveCollider = null;
	}

	void CompleteActiveTask() {
		Objective.text = "COMPLETED";
		SetHandsActive (false);
		CurrentObjectiveCollider.gameObject.GetComponent<GenericTask> ().PlayTaskSound ();
		CurrentObjectiveCollider.enabled = false;

	}


	void SetHandsActive(bool state) {
		if (state) {
			leftHand.SetActive (true);
			rightHand.SetActive (true);	
		} else {
			leftHand.SetActive(false);
			rightHand.SetActive(false);
		}

	
	}
}
