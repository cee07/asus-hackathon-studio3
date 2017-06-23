using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour {
	float y;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		y += Time.fixedDeltaTime * 100;
		transform.rotation = Quaternion.Euler(0,y,0);
	}
}
