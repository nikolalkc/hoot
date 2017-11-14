using UnityEngine;
using System.Collections;

public class AutoMoveAndRotate : MonoBehaviour {

	public Vector3andSpace moveUnitsPerSecond;
	public Vector3andSpace rotateDegreesPerSecond;
	public bool ignoreTimescale;
	float lastRealTime;
	public static bool positiveDirection = true;
	Vector3 initialPosition;
	bool moving = true;
	void Start()
	{
		initialPosition = transform.position;
		lastRealTime = Time.realtimeSinceStartup;
		
		int a = Random.Range(10,30);
		int b = Random.Range(10,30);
		int c = Random.Range(10,30);
		Vector3andSpace rotation = new Vector3andSpace ();
		rotation.value = new Vector3 (a, b, c);
		rotation.space = Space.Self;
		rotateDegreesPerSecond = rotation;


		int x = Random.Range (1, 4);
		int y = Random.Range (1, 4);
		int z = Random.Range (1, 4);
		Vector3andSpace direction = new Vector3andSpace ();
		direction.space = Space.Self;
		direction.value = new Vector3 (x, y, z);
		moveUnitsPerSecond = direction;
		
	}

	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown(0)) {
			positiveDirection = !positiveDirection;
			moveUnitsPerSecond.value = moveUnitsPerSecond.value * -1;
			rotateDegreesPerSecond.value = rotateDegreesPerSecond.value * -1;
		}
		if (Input.GetMouseButtonDown (1)) {
			moving = !moving;
			print (moving);
		}
		float deltaTime = Time.deltaTime;
		if (ignoreTimescale)
		{
			deltaTime = (Time.realtimeSinceStartup-lastRealTime);
			lastRealTime = Time.realtimeSinceStartup;
		}
		if (moving ) {
			transform.Translate (moveUnitsPerSecond.value * deltaTime, moveUnitsPerSecond.space);
			transform.Rotate (rotateDegreesPerSecond.value * deltaTime, moveUnitsPerSecond.space);
		}
	}

	[System.Serializable]
	public class Vector3andSpace
	{
		public Vector3 value;
		public Space space = Space.Self;
	}

}
