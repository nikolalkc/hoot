using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAnotherLevel : MonoBehaviour {
	public int scene_index;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider col) {
		SceneManager.LoadScene (scene_index);
	}
}
