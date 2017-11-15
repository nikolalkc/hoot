using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericTask : MonoBehaviour {
	public int Index;
	public bool isEnabled;
	public AudioSource task_fx_source;
	public AudioClip sfx;
	// Use this for initialization
	void Start () {
		task_fx_source = gameObject.AddComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayTaskSound() {

		if (sfx) {
			task_fx_source.PlayOneShot (sfx);
		}
	}
}
