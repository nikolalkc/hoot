using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitLights : MonoBehaviour {
	Light[] lights;
	Text[] room_labels;
	// Use this for initialization
	void Start () {
		room_labels = gameObject.GetComponentsInChildren<Text> ();
		foreach (var label in room_labels) {
			label.enabled = false;
		}
		lights = gameObject.GetComponentsInChildren<Light> ();
		foreach (var light in lights) {
			light.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TurnOnLights() {
		foreach (var light in lights) {
			light.enabled = true;
		}	
		foreach (var label in room_labels) {
			label.enabled = true;
		}
	}
}
