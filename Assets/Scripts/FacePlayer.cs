using UnityEngine;
using System.Collections;

public class FacePlayer : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 n = Camera.main.transform.position - transform.position; 
		transform.rotation = Quaternion.LookRotation( n );
	}
}
