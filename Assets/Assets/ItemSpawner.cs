using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

	public List<GameObject> objects =  new List<GameObject>();
	private int mask;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay(transform.position, transform.forward, Color.green);

		if (Input.GetKeyDown (KeyCode.A)) {
			SpawnItem (0);
		}

		if (Input.GetKeyDown (KeyCode.S)) {
			SpawnItem (1);
		}
	}

	public void SpawnItem(int objectIndex) {
		//items [itemIndex].transform.position;
		RaycastHit hit;
		if (objects [objectIndex].GetComponent<Item>().floorItem) {
			mask = 1 << 8;
			if (Physics.Raycast (transform.position, transform.forward, out hit, Mathf.Infinity, mask)) {
				objects [objectIndex].transform.position = hit.point;
				objects [objectIndex].SetActive (true);
				objects [objectIndex].GetComponent<Animator>().SetTrigger("PopUp");
			}
		} else {
			mask = 1 << 9;
			if (Physics.Raycast (transform.position, transform.forward, out hit, Mathf.Infinity, mask)) {
				objects [objectIndex].transform.position = hit.point;
				objects [objectIndex].transform.rotation = hit.transform.rotation;
				objects [objectIndex].SetActive (true);
				objects [objectIndex].GetComponent<Animator>().SetTrigger("PopUp");
			}
		}





	}
}
