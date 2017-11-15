using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public GameObject leftHand, rightHand;
	public Text Objective;
	public string[] objectives;
	public int objective_index = 0;
	Collider CurrentObjectiveCollider;
	public int nextTaskTime = 3;
	public GameObject LightHolder;
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
			int col_task_index = col.gameObject.GetComponent<GenericTask> ().TaskIndex;
			if (col_task_index == objective_index) {
				SetHandsActive (true);	
			}

		}
		CurrentObjectiveCollider = col;
	}

	void OnTriggerExit(Collider col) {
		if (col.tag == "task") {
			SetHandsActive (false);
		}
	}

	void CompleteActiveTask() {
		DoStuff ();
		Objective.text = "";
		SetHandsActive (false);
		CurrentObjectiveCollider.gameObject.GetComponent<GenericTask> ().PlayTaskSound ();
		CurrentObjectiveCollider.enabled = false;
		Invoke ("EnableNextTask", nextTaskTime);
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

	void EnableNextTask() {
		if (objective_index < objectives.Length-1) {
			objective_index++;
			Objective.text = objectives [objective_index];		
		} else {
			//Objective.text = "WELL DONE. GAME COMPLETED";
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}

	}



	void DoStuff() {
		switch (objective_index) {
		case 0:
			LightHolder.GetComponent<InitLights> ().TurnOnLights ();
			break;
		default:
			break;
		}
	
	}


}
